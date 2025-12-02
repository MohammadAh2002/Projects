using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFileStorageService
    {

        enum enFileType { Image = 1, Document = 2 }

        Task<string> SaveFileAsync(IFormFile file, string FileName, enFileType FileType);

        public bool ValidateExtension(IFormFile File, enFileType FileType);
    }
}
