using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIt3d.DAL.Entities
{
    public class ProductSize : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string Size { get; set; } = string.Empty; // XS, S, M, L, XL, XXL, etc.

        public int StockQuantity { get; set; } = 0;

        // Foreign key
        public Guid ProductId { get; set; }

        // Navigation property
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;
    }
}
