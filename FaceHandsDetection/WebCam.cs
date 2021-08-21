using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
namespace FaceHandsDetection
{
    public static class WebCam
    {
        private static FilterInfoCollection VideoCaptureDevices;
        private static object Lock = new object();
        public static VideoCaptureDevice FinalVideo;
        private static Bitmap _NewFrame;
        private volatile static bool IsRunning=false;
        public static Bitmap NewFrame
        {
            get
            {
                lock (Lock)
                {
                    return _NewFrame;
                }
            }
            set
            {
                lock (Lock)
                {
                    _NewFrame = value;
                }
            }
        }
        private static float Brightness;
        public static List<string> ReturnCameraList()
        {
            List<string> list = new List<string>() ;
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            for (int i = 0; i < VideoCaptureDevices.Count; i++)
            {
                list.Add(VideoCaptureDevices[i].Name);
            }
            return list;
        }
        public static void StartCamera(int index)
        {
            Brightness = 1.0f;
            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[index].MonikerString);
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            FinalVideo.Start();
            IsRunning = true;
        }
        public static bool ReturnCameraState()
        {
            return IsRunning;
        }
        public static void SetBrightness(float var)
        {
            Brightness = var;
        }
        public static Bitmap ReturnNewBitmap()
        {
            return NewFrame;
        }
        private static void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var buf = ImageHelper.AdjustBrightness((Bitmap)eventArgs.Frame.Clone(), Brightness);
            NewFrame = Recognize.RecognizeBodyParts(buf);
            
        }
        public static void StopCamera()
        {
            if (FinalVideo != null)
            {
                IsRunning = false;
                FinalVideo.SignalToStop();
                FinalVideo.WaitForStop();
                FinalVideo = null;
            }
        }
    }
}
