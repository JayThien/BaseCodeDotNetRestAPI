using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.ThirdParty.Dropbox
{
    public interface IDropboxService
    {
        Task<string> Upload(IFormFile file);
    }
}
