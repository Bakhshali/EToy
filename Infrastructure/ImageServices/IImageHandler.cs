using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImageServices
{
    public interface IImageHandler
    {
        Task<IActionResult> UploadImage(IFormFile file, string owner, string imgname);
        IActionResult RemoveImage(string owner, string imgname);
        IActionResult RenameImage(string owner, string oldname, string newname);
        Task<string> GetLocationOfUploadedImage(IFormFile image, string owner, string imageName = null);
    }
}
