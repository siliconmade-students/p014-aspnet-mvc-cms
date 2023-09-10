using Cms.SharedLibrary.File.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.SharedLibrary.File
{
    public class FileSaver : IFileSaver
    { 
        public string SaveImage(IFormFile formFile, string uploadPath)
        {
            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
            var fileExtension = Path.GetExtension(formFile.FileName);
            var lastName ="imageFile-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileExtension;
            var stream = new FileStream(uploadPath + "\\"+lastName, FileMode.Create);
            formFile.CopyTo(stream);
            stream.Close();

            return lastName;
        }
    }
}
