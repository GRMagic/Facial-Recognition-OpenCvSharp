using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Windows.Forms;

namespace Facial_Recognition.Helpers
{
    public static class MyExtensions
    {
        public static Timer SendToPictureBox(this VideoCapture videoCapture, PictureBox pictureBox, Action<Mat> preDrawAction = null)
        {
            var timer = new Timer();
            timer.Interval = (int)(1000 / videoCapture.Fps);
            timer.Tick += (s, e) => {
                var currentFrame = videoCapture.RetrieveMat();
                preDrawAction?.Invoke(currentFrame);
                pictureBox.Renderize(currentFrame);
            };
            timer.Start();
            return timer;
        }

        public static void Renderize(this PictureBox pictureBox, Mat mat)
        {
            var resized = mat.Resize(new Size(pictureBox.Width, pictureBox.Height));
            pictureBox.Image = BitmapConverter.ToBitmap(resized); 
            GC.Collect(); // TODO: Find a better solution for bitmap memory leak.
        }
    }
}
