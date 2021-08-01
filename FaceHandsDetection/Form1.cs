using System;
using System.Windows.Forms;

namespace FaceHandsDetection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        private void EnableControls(bool a)
        {
            StartCameraButton.Enabled = a;
            StopCameraButton.Enabled = !a;
            BrightnessTrackbar.Enabled = !a;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Recognize.InitRecognition();
            WebCam.InitWebcam(ref this.CameraPictureBox,ref this.CamerasList);
            StopCameraButton.Enabled = false;
        }

        private void StartCameraButton_Click(object sender, EventArgs e)
        {
            if (CamerasList.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a camera!", "Error!");
                return;
            }
            WebCam.StartCamera(CamerasList.SelectedIndex);
            EnableControls(false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WebCam.StopCamera();
        }

        private void StopCameraButton_Click(object sender, EventArgs e)
        {
            WebCam.StopCamera();
            EnableControls(true);
        }

        private void SelectPictureButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveButton.Enabled = true;
                   
                    Picture.RecognizeBodyPartsInPicture(ref this.photoPictureBox, openFileDialog.FileName);
                }
            }
        }

        private void BrightnessTrackbar_Scroll(object sender, EventArgs e)
        {
            float val = Convert.ToSingle(BrightnessTrackbar.Value / 10.0)+1.0f;
            WebCam.SetBrightness(val);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(FileNameTextBox.Text=="")
            {
                MessageBox.Show("Please enter a file name with extension!", "Error!");
                return;
            }
            using (FolderBrowserDialog saveFolderDialog = new FolderBrowserDialog())
            {
                if (saveFolderDialog.ShowDialog() == DialogResult.OK)
                {
                    this.photoPictureBox.Image.Save(saveFolderDialog.SelectedPath + "\\"+ FileNameTextBox.Text);
                }
            }
           
        }
    }
}
