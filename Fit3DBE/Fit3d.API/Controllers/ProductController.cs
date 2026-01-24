using System;
using System.IO;
using System.Threading.Tasks;
using Fit3d.BLL.DTOs;
using Fit3d.BLL.Interfaces;
using Fit3d.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fit3d.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IOrderService _orderService;
        private readonly IFileService _fileService;

        public ProductController(
            IProductService service,
            IOrderService orderService,
            IFileService fileService)
        {
            _service = service;
            _orderService = orderService;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaging([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? search = null, [FromQuery] Guid? categoryId = null)
        {
            return Ok(await _service.GetPagingAsync(page, size, search, categoryId));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductDTO createDto)
        {
            var result = await _service.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDTO updateDto)
        {
            var result = await _service.UpdateAsync(id, updateDto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _service.DeleteAsync(id)) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}/download")]
        public async Task<IActionResult> DownloadModel(Guid id, [FromQuery] Guid userId)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound("Sản phẩm không tồn tại.");
            bool hasPurchased = await _orderService.HasUserPurchasedProductAsync(userId, id);
            if (!hasPurchased)
            {
                return StatusCode(403, "Bạn chưa mua sản phẩm này hoặc đơn hàng chưa thanh toán.");
            }
            if (string.IsNullOrEmpty(product.ModelFilePath))
            {
                return NotFound("Sản phẩm này chưa có file gốc để tải.");
            }
            var fileStream = _fileService.GetFileStream(product.ModelFilePath);
            if (fileStream == null) return NotFound("File bị lỗi hoặc đã bị xóa trên server.");
            string fileName = Path.GetFileName(product.ModelFilePath);
            return File(fileStream, "application/octet-stream", fileName);
        }

        [HttpPost("{id}/colors")]
        public async Task<IActionResult> AddColor(Guid id, [FromBody] CreateProductColorDTO colorDto)
        {
            var result = await _service.AddColorAsync(id, colorDto);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpDelete("colors/{colorId}")]
        public async Task<IActionResult> DeleteColor(Guid colorId)
        {
            return await _service.DeleteColorAsync(colorId) ? NoContent() : NotFound();
        }

        [HttpPost("{id}/sizes")]
        public async Task<IActionResult> AddSize(Guid id, [FromBody] CreateProductSizeDTO sizeDto)
        {
            var result = await _service.AddSizeAsync(id, sizeDto);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpDelete("sizes/{sizeId}")]
        public async Task<IActionResult> DeleteSize(Guid sizeId)
        {
            return await _service.DeleteSizeAsync(sizeId) ? NoContent() : NotFound();
        }
    }
}