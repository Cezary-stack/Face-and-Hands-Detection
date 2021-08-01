using System.Windows.Forms;
using System.Drawing;
namespace FaceHandsDetection
{
    public static class Picture
    {
        public static void RecognizeBodyPartsInPicture(ref PictureBox pb1,string path)
        {
            using (var bmp = new Bitmap(path))
            {
                pb1.Image = Recognize.RecognizeBodyParts(bmp);
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
