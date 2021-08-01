using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using System.Windows.Forms;
namespace FaceHandsDetection
{
    public static class WebCam
    {
        private static FilterInfoCollection VideoCaptureDevices;
        private static VideoCaptureDevice FinalVideo;
        private static PictureBox pb1;
        private static float Brightness;
        private static volatile bool stop, done;
        public static void InitWebcam(ref PictureBox x, ref ComboBox y)
        {
            pb1 = x;
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            for (int i = 0; i < VideoCaptureDevices.Count; i++)
            {
                y.Items.Add(VideoCaptureDevices[i].Name);
            }
        }
        public static void StartCamera(int index)
        {
            stop = false;
            done = false;
            Brightness = 1.0f;
            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[index].MonikerString);
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            FinalVideo.Start();
        }
        public static void SetBrightness(float var)
        {
            Brightness = var;
        }
        private static void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var buf = ImageHelper.AdjustBrightness((Bitmap)eventArgs.Frame.Clone(), Brightness);
            var bmp = Recognize.RecognizeBodyParts(buf);
            if (stop == false)
            {

                pb1.BeginInvoke((MethodInvoker)delegate
                {
                    pb1.Image = bmp;
                    pb1.SizeMode = PictureBoxSizeMode.StretchImage;
                });

            }
            else
            {
                done = true;
            }
        }
        public static void StopCamera()
        {
            if (FinalVideo != null)
            {
                stop = true;
                while (done == false) ;
                FinalVideo.SignalToStop();
                FinalVideo.WaitForStop();
                pb1.BeginInvoke((MethodInvoker)delegate
                {
                    pb1.Image = null;
                });
                FinalVideo = null;
            }
        }
    }
}
