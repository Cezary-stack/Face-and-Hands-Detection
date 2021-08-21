using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
namespace FaceHandsDetection
{
    public static class Recognize
    {
        private static Net tfFaceDetector;
        private static Net tfHandsDetector;
        public static void InitRecognition()
        {
            tfFaceDetector = DnnInvoke.ReadNetFromTensorflow(Config.FacePath, Config.FacePathtxt);
            tfHandsDetector = DnnInvoke.ReadNetFromTensorflow(Config.HandPath, Config.HandPathtxt);
            tfFaceDetector.SetPreferableBackend(Emgu.CV.Dnn.Backend.Cuda);
            tfFaceDetector.SetPreferableTarget(Target.Cuda);
            tfHandsDetector.SetPreferableBackend(Emgu.CV.Dnn.Backend.Cuda);
            tfHandsDetector.SetPreferableTarget(Target.Cuda);

        }
        private static List<Rectangle> RecognizeFace(ref Image<Bgr, byte> image, ref Mat blob)
        {
            List<Rectangle> list = new List<Rectangle>();
            tfFaceDetector.SetInput(blob);
            var prob = tfFaceDetector.Forward();
            float[,,,] flt = (float[,,,])prob.GetData();
            int cols = image.Width;
            int rows = image.Height;
            for (int x = 0; x < flt.GetLength(2); x++)
            {
                if (flt[0, 0, x, 2] > 0.5)
                {
                    int left = Convert.ToInt32(flt[0, 0, x, 3] * cols);
                    int top = Convert.ToInt32(flt[0, 0, x, 4] * rows);
                    int right = Convert.ToInt32(flt[0, 0, x, 5] * cols);
                    int bottom = Convert.ToInt32(flt[0, 0, x, 6] * rows);
                    var rect = new Rectangle(left, top, right - left, bottom - top);
                    list.Add(rect);
                }
            }
            return list;
        }
        private static List<Rectangle> RecognizeHands(ref Image<Bgr, byte> image, ref Mat blob)
        {
            List<Rectangle> list = new List<Rectangle>();
            tfHandsDetector.SetInput(blob);
            var prob = tfHandsDetector.Forward();
            float[,,,] flt = (float[,,,])prob.GetData();
            int cols = image.Width;
            int rows = image.Height;
            for (int x = 0; x < flt.GetLength(2); x++)
            {
                if (flt[0, 0, x, 2] > 0.6)
                {
                    int left = Convert.ToInt32(flt[0, 0, x, 3] * cols);
                    int top = Convert.ToInt32(flt[0, 0, x, 4] * rows);
                    int right = Convert.ToInt32(flt[0, 0, x, 5] * cols);
                    int bottom = Convert.ToInt32(flt[0, 0, x, 6] * rows);
                    var rect = new Rectangle(left, top, right - left, bottom - top);
                    list.Add(rect);
                }
            }
            return list;
        }
        public static Bitmap RecognizeBodyParts(Bitmap bmp)
        {
            var image = BitmapExtension.ToImage<Bgr, byte>(bmp).Resize(450, 370, Inter.Cubic);
            var blob = DnnInvoke.BlobFromImage(image, 1, new Size(400, 300), new MCvScalar(0, 0, 0), true);
            var faces = RecognizeFace(ref image, ref blob);
            var hands = RecognizeHands(ref image, ref blob);
            foreach (var face in faces)
            {
                image.Draw(face, new Bgr(0, 0, 255), 2);
            }
            foreach (var hand in hands)
            {
                image.Draw(hand, new Bgr(0, 0, 255), 2);
            }
            return ImageHelper.ResizeImage(image.ToBitmap<Bgr, byte>(), bmp.Width, bmp.Height);
        }
    }
}
