using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIt3d.DAL.Entities
{
    public class ProductColor : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string ColorName { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? ColorCode { get; set; } // Hex color code, e.g., #FF5733

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        public int StockQuantity { get; set; } = 0;

        // Foreign key
        public Guid ProductId { get; set; }

        // Navigation property
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;
    }
}
