using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImageServices
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile file, string owner, string imgname);
        string RemoveImage(string owner, string imgname);
        string RenameImage(string owner, string oldname,string newname);

    }
}
