using ALTC_WebSite.Models;

using ALTC_Website.ViewModels;

using Microsoft.Extensions.Hosting;

namespace ALTC_Website.Abstract
{
    public static class File
    {
        public static string Upload(string url, IFormFile file)
        {
           // string uploadPath = Path.Combine(hostEnvironment.WebRootPath, "Files");
            string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(url, fileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }
    }
}
