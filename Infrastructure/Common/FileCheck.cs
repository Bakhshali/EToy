using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common
{
    public static class FileCheck
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public static bool IsGreats(this IFormFile file, int mb)
        {
            return file.Length < mb * 1024 * 1024;
        }

        public static bool IsOkay(this IFormFile file, int mb)
        {
            return IsImage(file) && IsGreats(file, mb);
        }
    }
}
