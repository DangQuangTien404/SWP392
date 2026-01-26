using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Fit3d.BLL.Services
{
    public interface IFileService
    {
        Task<string?> SaveFileAsync(IFormFile? file, string folderName);
        FileStream? GetFileStream(string filePath);
    }

    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string?> SaveFileAsync(IFormFile? file, string folderName)
        {
            if (file == null || file.Length == 0) return null;

            // 1. Tạo đường dẫn thư mục lưu: wwwroot/uploads/{folderName}
            // Ví dụ: wwwroot/uploads/models hoặc wwwroot/uploads/previews
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", folderName);

            // Nếu thư mục chưa có thì tạo mới
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            // 2. Tạo tên file duy nhất (dùng GUID) để không bị ghi đè file cũ
            // Ví dụ: guid-123-456_model.zip
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return Path.Combine("uploads", folderName, uniqueFileName).Replace("\\", "/");
        }

        public FileStream? GetFileStream(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return null;

            string fullPath = Path.Combine(_environment.WebRootPath, filePath);

            if (!System.IO.File.Exists(fullPath)) return null;

            return new FileStream(fullPath, FileMode.Open, FileAccess.Read);
        }
    }
}