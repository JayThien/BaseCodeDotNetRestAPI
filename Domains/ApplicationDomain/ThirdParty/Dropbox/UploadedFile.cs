using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.ThirdParty.Dropbox
{
    public class UploadedFile
    {
        public bool IsUploaded { set; get; }
        public int Id { set; get; }
        public string UploadedPath { set; get; }
        public string ContentType { set; get; }
    }
}
