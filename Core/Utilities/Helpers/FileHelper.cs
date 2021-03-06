using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        public static string Save(string path, IFormFile file)
        {
            using (var stream = System.IO.File.Create(path))
            {
                var fileExtension = Path.GetExtension(file.FileName);
                var newFileName = Guid.NewGuid() + fileExtension;
                file.CopyTo(stream);
                return newFileName;
            }
        }
    }
}
