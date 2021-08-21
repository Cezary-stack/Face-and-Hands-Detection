using System;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
namespace FaceHandsDetection
{
    public partial class Form1 : Form
    {
        private Thread threadCam,threadPhoto;
        private Semaphore A = new Semaphore(0, 1);
        private Semaphore B = new Semaphore(0, 1);
        private bool stop = false;
        string file;
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
        private void InitThreads()
        {
            threadPhoto = new Thread(PhotoThread);
            threadPhoto.IsBackground = true;
            threadPhoto.Start();
            threadCam = new Thread(WebCamThread);
            threadCam.IsBackground = true;
            threadCam.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Recognize.InitRecognition();
            InitThreads();
            CameraPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            photoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            var CamList = WebCam.ReturnCameraList();
            foreach(var camera in CamList)
            {
                this.CamerasList.Items.Add(camera);
            }
        }
        private void EnableFileSave(bool a)
        {
            this.Invoke((MethodInvoker)delegate
            {
                SelectPictureButton.Enabled = a;
                SaveButton.Enabled = a;
            }

            );
        }
        private void SetImage(Bitmap bitmap)
        {
            if (CameraPictureBox.InvokeRequired)
            {
                CameraPictureBox.Invoke((MethodInvoker)delegate
                {
                    CameraPictureBox.Image = bitmap;
                }
                );
            }
            else
            {
                CameraPictureBox.Image = bitmap;
            }
        }
        private void PhotoThread()
        {
            while(true)
            {
                B.WaitOne();
                photoPictureBox.Invoke((MethodInvoker)delegate
                {
                    photoPictureBox.Image = Picture.RecognizeBodyPartsInPicture(file);
                }
                );
                EnableFileSave(true);
            }
        }
        private void WebCamThread()
        {
            while(true)
            {
                stop = false;
                A.WaitOne();
                while(stop==false)
                {
                    SetImage(WebCam.ReturnNewBitmap());
                }
                SetImage(null);
            }
        }
        private void StartCameraButton_Click(object sender, EventArgs e)
        {
            if (CamerasList.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a camera!", "Error!");
                return;
            }
            WebCam.StartCamera(CamerasList.SelectedIndex);
            A.Release();
            EnableControls(false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop = true;
            WebCam.StopCamera();
        }

        private void StopCameraButton_Click(object sender, EventArgs e)
        {
            stop = true;
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
                  
                    file = openFileDialog.FileName;
                    EnableFileSave(false);
                    B.Release();
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
