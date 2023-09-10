using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.SharedLibrary.File.Abstract
{
    public interface IFileSaver
    {
        string SaveImage(IFormFile formFile,string Path);
    }
}
