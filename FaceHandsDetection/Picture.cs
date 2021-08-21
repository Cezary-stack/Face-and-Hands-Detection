using System.Windows.Forms;
using System.Drawing;
namespace FaceHandsDetection
{
    public static class Picture
    {
        public static Bitmap RecognizeBodyPartsInPicture(string path)
        {
            Bitmap bitmap = null;
            using (var bmp = new Bitmap(path))
            {
                bitmap = Recognize.RecognizeBodyParts(bmp);
             
            }
            return bitmap;
        }
    }
}
