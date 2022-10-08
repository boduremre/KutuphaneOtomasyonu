using System.IO;


namespace MrbdrCMS.Helper
{
    public static class ImageDeleteHelper
    {
        public static void DeleteImage(string ImageUrl)
        {
            string imageName = Path.GetFileName(ImageUrl);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/images", imageName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}