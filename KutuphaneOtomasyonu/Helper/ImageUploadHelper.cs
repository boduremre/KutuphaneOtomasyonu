using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace KutuphaneOtomasyonu.Helper
{
    // http://blog.alicancevik.com/net-core-mvc-resim-yukleme/
    public static class ImageUploadHelper
    {
        public static string UploadImage(IFormFile file, string subDir)
        {
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);
                string imageName = Guid.NewGuid() + imageExtension;
                string path = String.Format("{0}/{1}/{2}/{3}", Directory.GetCurrentDirectory(), "wwwroot/images", subDir, imageName);
                FileStream stream = new FileStream(path, FileMode.Create);
                file.CopyToAsync(stream);
                stream.Flush();

                return String.Format("/images/{0}/{1}", subDir, imageName);
            }
            else
            {
                return null;
            }
        }
    }
}
