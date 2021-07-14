using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Facial_Recognition.Helpers;
using System.IO;
using OpenCvSharp.Face;

namespace Facial_Recognition
{
    public partial class Form1 : Form
    {
        VideoCapture videoCapture;
        Timer timer;
        CascadeClassifier faceCascadeClassifier;
        EigenFaceRecognizer recognizer = null;
        bool faceRecognizeEnabled;
        bool facesDetectionEnabled;
        Rect[] faces = new Rect[0];
        DirectoryInfo trainedDirectory;
        bool saveFacesEnabled = false;
        int currentImageSample = 0;
        DateTime lastSave = DateTime.MinValue;
        int imagesCount = 20;
        
        public Form1()
        {
            InitializeComponent();
            faceCascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");
            trainedDirectory = Directory.CreateDirectory("TrainedImages");

            if (File.Exists("recognizer.yaml"))
                btnLoadTrain.Enabled = true;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (videoCapture == null)
            {
                videoCapture = new VideoCapture(0);
                timer = videoCapture.SendToPictureBox(picCapture, DrawRectangle);
                btnDetect.Enabled = true;
            }
        }

        private void btnDetect_Click(object sender, EventArgs e) => btnAddPerson.Enabled = facesDetectionEnabled = !facesDetectionEnabled;

        public void DrawRectangle(Mat currentFrame)
        {
            txtRecognize.Text = "";
            if (facesDetectionEnabled) 
            {
                txtRecognize.Text = "Nobody";

                var grayImage = currentFrame.CvtColor(ColorConversionCodes.BGR2GRAY);
                picGrayScale.Renderize(grayImage);
                grayImage = grayImage.EqualizeHist();
                picEqualize.Renderize(grayImage);
                faces = faceCascadeClassifier.DetectMultiScale(grayImage);
                
                var firstFace = faces.FirstOrDefault();
                if (firstFace != Rect.Empty)
                {
                    txtRecognize.Text = "Someone";

                    var center = new Point2f(firstFace.Width / 2 + firstFace.Left, firstFace.Height / 2 + firstFace.Top);
                    var cropped = currentFrame.GetRectSubPix(firstFace.Size, center);
                    picDetect.Renderize(cropped);

                    Mat croppedResizedSquare = null;

                    if (saveFacesEnabled && DateTime.Now >= lastSave.AddMilliseconds(500))
                    {
                        var size = Math.Max(firstFace.Width, firstFace.Height);
                        var croppedSquare = currentFrame.GetRectSubPix(new OpenCvSharp.Size (size, size), center);
                        croppedResizedSquare = croppedSquare.Resize(new OpenCvSharp.Size(200, 200), 0, 0, InterpolationFlags.Cubic);
                        var success = croppedResizedSquare.SaveImage(Path.Combine(trainedDirectory.FullName, $"{txtPersonName.Text}_{currentImageSample++}.jpg"));
                        lastSave = DateTime.Now;
                        if(currentImageSample == imagesCount || !success)
                        {
                            currentImageSample = 0;
                            btnAddPerson.Enabled = true;
                            txtPersonName.Enabled = true;
                            saveFacesEnabled = false;
                            if (success)
                            {
                                MessageBox.Show("Images saved!");
                            }
                            else
                            {
                                MessageBox.Show("Image NOT saved!");
                            }
                        }
                    }

                    if (faceRecognizeEnabled)
                    {
                        if (croppedResizedSquare == null) {
                            var size = Math.Max(firstFace.Width, firstFace.Height);
                            var croppedSquare = currentFrame.GetRectSubPix(new OpenCvSharp.Size(size, size), center);
                            croppedResizedSquare = croppedSquare.Resize(new OpenCvSharp.Size(200, 200), 0, 0, InterpolationFlags.Cubic);
                        }
                        
                        var graySquare = croppedResizedSquare
                            .CvtColor(ColorConversionCodes.BGR2GRAY)
                            .EqualizeHist();

                        recognizer.Predict(graySquare, out var label, out var confidence);
                        if(label >= 0) 
                        { 
                            txtRecognize.Text = recognizer.GetLabelInfo(label) + " -> " + confidence;
                        }
                    }
                }

                foreach (var face in faces)
                {
                    currentFrame.Rectangle(face, Scalar.DarkRed);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timer?.Dispose();
            faceCascadeClassifier?.Dispose();
            videoCapture?.Dispose();
            base.OnFormClosing(e);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPersonName.Text) || txtPersonName.Text.Contains('_'))
            {
                MessageBox.Show("Invalid person name");
                return;
            }
            btnAddPerson.Enabled = false;
            txtPersonName.Enabled = false;
            saveFacesEnabled = true;
            faceRecognizeEnabled = false;
            btnRecognize.Enabled = false;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            recognizer?.Dispose();
            List<string> persons = new List<string>();

            var files = trainedDirectory.GetFiles("*.jpg");

            if (files.Length == 0) return;

            var labels = new List<int>();
            foreach (var file in files)
            {
                var personName = file.Name.Split('_')[0];
                
                var index = persons.IndexOf(personName);
                if (index < 0)
                {
                    persons.Add(personName);
                    labels.Add(persons.Count - 1);
                }
                else
                {
                    labels.Add(index);
                }
            }

            recognizer = EigenFaceRecognizer.Create(5, 5000); // params
            recognizer.Train(TrainImages(files), labels);
            for(int i=0; i< persons.Count; i++)
                recognizer.SetLabelInfo(i, persons[i]);

            recognizer.Write("recognizer.yaml");

            btnRecognize.Enabled = true;
            btnLoadTrain.Enabled = true;
        }

        IEnumerable<Mat> TrainImages(FileInfo[] files)
        {
            foreach(var file in files)
            {
                var stream = new FileStream(file.FullName, FileMode.Open);
                var mat = Mat.FromStream(stream, ImreadModes.Grayscale)
                    .EqualizeHist();
                yield return mat;
            }
        }

        private void btnRecognize_Click(object sender, EventArgs e)
        {
            if (recognizer == null)
            {
                MessageBox.Show("Not trained yet!");
                return;
            }
            faceRecognizeEnabled = true;
            btnRecognize.Enabled = false;
        }

        private void btnLoadTrain_Click(object sender, EventArgs e)
        {
            recognizer?.Dispose();
            recognizer = EigenFaceRecognizer.Create();
            recognizer.Read("recognizer.yaml");

            btnRecognize.Enabled = true;
            faceRecognizeEnabled = false;
        }
    }
}
