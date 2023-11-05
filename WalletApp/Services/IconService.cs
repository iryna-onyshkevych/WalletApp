using System.Drawing;
using System.Drawing.Imaging;

namespace WalletApp.Services
{
    public static class IconService
    {
        public static byte[] GenerateIcon()
        {
            using (Bitmap icon = new Bitmap(50, 50))
            using (Graphics g = Graphics.FromImage(icon))
            {
                g.Clear(Color.DarkBlue);

                using (Font font = new Font("Arial", 12))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    g.DrawString("Icon", font, brush, new PointF(5, 20));
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    icon.Save(stream, ImageFormat.Png);
                    byte[] iconBytes = stream.ToArray();
                    return iconBytes;
                }
            }
        }
    }
}
