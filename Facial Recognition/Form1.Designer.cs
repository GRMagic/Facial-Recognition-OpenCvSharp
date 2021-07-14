
namespace Facial_Recognition
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.picDetect = new System.Windows.Forms.PictureBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnDetect = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.picGrayScale = new System.Windows.Forms.PictureBox();
            this.lbGrayScale = new System.Windows.Forms.Label();
            this.lbEqualize = new System.Windows.Forms.Label();
            this.picEqualize = new System.Windows.Forms.PictureBox();
            this.txtRecognize = new System.Windows.Forms.TextBox();
            this.btnRecognize = new System.Windows.Forms.Button();
            this.btnLoadTrain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGrayScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEqualize)).BeginInit();
            this.SuspendLayout();
            // 
            // picCapture
            // 
            this.picCapture.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picCapture.Location = new System.Drawing.Point(12, 12);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(600, 400);
            this.picCapture.TabIndex = 0;
            this.picCapture.TabStop = false;
            // 
            // picDetect
            // 
            this.picDetect.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picDetect.Location = new System.Drawing.Point(628, 71);
            this.picDetect.Name = "picDetect";
            this.picDetect.Size = new System.Drawing.Size(161, 148);
            this.picDetect.TabIndex = 1;
            this.picDetect.TabStop = false;
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(627, 258);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.PlaceholderText = "Person Name";
            this.txtPersonName.Size = new System.Drawing.Size(160, 23);
            this.txtPersonName.TabIndex = 4;
            this.txtPersonName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(628, 13);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(160, 23);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnDetect
            // 
            this.btnDetect.Enabled = false;
            this.btnDetect.Location = new System.Drawing.Point(628, 42);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(160, 23);
            this.btnDetect.TabIndex = 2;
            this.btnDetect.Text = "Detect Faces";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDetect_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Enabled = false;
            this.btnAddPerson.Location = new System.Drawing.Point(627, 287);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(160, 23);
            this.btnAddPerson.TabIndex = 5;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(627, 316);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(160, 23);
            this.btnTrain.TabIndex = 6;
            this.btnTrain.Text = "Train Images";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // picGrayScale
            // 
            this.picGrayScale.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picGrayScale.Location = new System.Drawing.Point(12, 444);
            this.picGrayScale.Name = "picGrayScale";
            this.picGrayScale.Size = new System.Drawing.Size(150, 100);
            this.picGrayScale.TabIndex = 8;
            this.picGrayScale.TabStop = false;
            // 
            // lbGrayScale
            // 
            this.lbGrayScale.AutoSize = true;
            this.lbGrayScale.Location = new System.Drawing.Point(12, 426);
            this.lbGrayScale.Name = "lbGrayScale";
            this.lbGrayScale.Size = new System.Drawing.Size(68, 15);
            this.lbGrayScale.TabIndex = 9;
            this.lbGrayScale.Text = "Gray Scaled";
            // 
            // lbEqualize
            // 
            this.lbEqualize.AutoSize = true;
            this.lbEqualize.Location = new System.Drawing.Point(168, 426);
            this.lbEqualize.Name = "lbEqualize";
            this.lbEqualize.Size = new System.Drawing.Size(57, 15);
            this.lbEqualize.TabIndex = 11;
            this.lbEqualize.Text = "Equalized";
            // 
            // picEqualize
            // 
            this.picEqualize.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picEqualize.Location = new System.Drawing.Point(168, 444);
            this.picEqualize.Name = "picEqualize";
            this.picEqualize.Size = new System.Drawing.Size(150, 100);
            this.picEqualize.TabIndex = 10;
            this.picEqualize.TabStop = false;
            // 
            // txtRecognize
            // 
            this.txtRecognize.Enabled = false;
            this.txtRecognize.Location = new System.Drawing.Point(627, 225);
            this.txtRecognize.Name = "txtRecognize";
            this.txtRecognize.Size = new System.Drawing.Size(160, 23);
            this.txtRecognize.TabIndex = 3;
            this.txtRecognize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRecognize
            // 
            this.btnRecognize.Enabled = false;
            this.btnRecognize.Location = new System.Drawing.Point(627, 345);
            this.btnRecognize.Name = "btnRecognize";
            this.btnRecognize.Size = new System.Drawing.Size(161, 23);
            this.btnRecognize.TabIndex = 7;
            this.btnRecognize.Text = "Recognize Persons";
            this.btnRecognize.UseVisualStyleBackColor = true;
            this.btnRecognize.Click += new System.EventHandler(this.btnRecognize_Click);
            // 
            // btnLoadTrain
            // 
            this.btnLoadTrain.Enabled = false;
            this.btnLoadTrain.Location = new System.Drawing.Point(627, 389);
            this.btnLoadTrain.Name = "btnLoadTrain";
            this.btnLoadTrain.Size = new System.Drawing.Size(160, 23);
            this.btnLoadTrain.TabIndex = 8;
            this.btnLoadTrain.Text = "Load Last Train";
            this.btnLoadTrain.UseVisualStyleBackColor = true;
            this.btnLoadTrain.Click += new System.EventHandler(this.btnLoadTrain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 557);
            this.Controls.Add(this.btnLoadTrain);
            this.Controls.Add(this.txtRecognize);
            this.Controls.Add(this.lbEqualize);
            this.Controls.Add(this.picEqualize);
            this.Controls.Add(this.lbGrayScale);
            this.Controls.Add(this.picGrayScale);
            this.Controls.Add(this.btnRecognize);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.picDetect);
            this.Controls.Add(this.picCapture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Facial Recognition";
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGrayScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEqualize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.PictureBox picDetect;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.PictureBox picGrayScale;
        private System.Windows.Forms.Label lbGrayScale;
        private System.Windows.Forms.Label lbEqualize;
        private System.Windows.Forms.PictureBox picEqualize;
        private System.Windows.Forms.TextBox txtRecognize;
        private System.Windows.Forms.Button btnRecognize;
        private System.Windows.Forms.Button btnLoadTrain;
    }
}

