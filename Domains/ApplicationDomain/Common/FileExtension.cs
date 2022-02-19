using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Common
{
    public static class FileExtension
    {
        public static bool FileExtensionContainImage(string fileExtention)
        {
            return fileExtention.Contains("image/");
        }

        public static bool FileExtensonContainVideo(string fileExtention)
        {
            return fileExtention.Contains("video/");
        }
    }
}
