using Microsoft.AspNetCore.Mvc;
using Fit3d.BLL.Services;
using Fit3d.BLL.Interfaces;
using Fit3d.BLL.DTOs;

namespace Fit3d.API.Controllers
{
    [ApiController]
    [Route("api/models")]
    public class Model3DController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public Model3DController(
            IFileService fileService,
            IOrderService orderService,
            IProductService productService)
        {
            _fileService = fileService;
            _orderService = orderService;
            _productService = productService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadModel(IFormFile file, [FromQuery] string type = "source")
        {
            if (file == null || file.Length == 0)
                return BadRequest("Vui lòng chọn file.");
            string folderName = type == "preview" ? "preview-models" : "source-models";
            string path = await _fileService.SaveFileAsync(file, folderName);
            return Ok(new { filePath = path });
        }

        [HttpGet("download/{productId}")]
        public async Task<IActionResult> DownloadModel(Guid productId, [FromQuery] Guid userId)
        {
            var product = await _productService.GetByIdAsync(productId);
            if (product == null) return NotFound("Sản phẩm không tồn tại.");
            bool hasPurchased = await _orderService.HasUserPurchasedProductAsync(userId, productId);
            if (!hasPurchased)
            {
                return StatusCode(403, "Bạn chưa mua sản phẩm này.");
            }
            if (string.IsNullOrEmpty(product.ModelFilePath))
            {
                return NotFound("File model chưa được cập nhật.");
            }
            var fileStream = _fileService.GetFileStream(product.ModelFilePath);
            if (fileStream == null) return NotFound("File không tìm thấy trên server.");

            string fileName = Path.GetFileName(product.ModelFilePath);
            return File(fileStream, "application/octet-stream", fileName);
        }
    }
}