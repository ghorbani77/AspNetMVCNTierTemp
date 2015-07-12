using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Helpers;

namespace MVC5.Common.Helpers.Extentions
{
    public static class ImageManage
    {
        public static byte[] AddWaterMark(string filePath, string text)
        {
            using (var img = System.Drawing.Image.FromFile(filePath))
            {
                using (var memStream = new MemoryStream())
                {
                    using (var bitmap = new Bitmap(img)) // to avoid GDI+ errors
                    {
                        bitmap.Save(memStream, ImageFormat.Png);
                        var content = memStream.ToArray();
                        var webImage = new WebImage(memStream);
                        webImage.AddTextWatermark(text, verticalAlign: "Top", horizontalAlign: "Left", fontColor: "Brown");
                        return webImage.GetBytes();
                    }
                }
            }
        }
    }
}