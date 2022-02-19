using System;
namespace ApplicationDomain.Infrastructures.ViewModels
{
    public class FileViewModel
    {
        public FileViewModel()
        {
        }

        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FileBase64String { get; set; }
    }
}
