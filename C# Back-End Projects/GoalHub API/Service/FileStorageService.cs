using Contracts;
using Entities.ConfigurationModels;
using Microsoft.AspNetCore.Http;
using static Contracts.IFileStorageService;

namespace Repository
{
    public class FileStorageService : IFileStorageService
    {
        private readonly StaticFilePaths _Settings;

        public FileStorageService(StaticFilePaths settings)
        {
            _Settings = settings;
        }

        public async Task<string> SaveFileAsync(IFormFile File, string FileName, enFileType FileType)
        {

            if (!ValidateExtension(File, FileType))
                throw new InvalidOperationException($"Invalid file type.");

            string uploadsPath = Path.Combine(_Settings.RootPath, FileDestination(FileType));

            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            string fullPath = Path.Combine(uploadsPath, FileName + Path.GetExtension(File.FileName).ToLowerInvariant());

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                await File.CopyToAsync(stream);
            }

            return Path.Combine(uploadsPath, FileName).Replace("\\", "/");

        }

        public bool ValidateExtension(IFormFile File, enFileType FileType)
        {

            string? extension = Path.GetExtension(File.FileName).ToLowerInvariant();

            if (FileType == enFileType.Image)
            {
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png"};
                return allowedExtensions.Contains(extension);
            }
            else if (FileType == enFileType.Document)
            {
                string[] allowedExtensions = new[] { ".pdf" };
                return allowedExtensions.Contains(extension);
            }

            return false;
        }

        private string FileDestination(enFileType FileType)
        {
            if(FileType == enFileType.Image)
                return _Settings.ImagesFolder;
            else if(FileType == enFileType.Document)
                return _Settings.DocumentsFolder;

            return _Settings.ImagesFolder;
        }
    }
}
