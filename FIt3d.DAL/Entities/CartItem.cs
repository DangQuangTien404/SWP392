using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIt3d.DAL.Entities
{
    public class CartItem : BaseEntity
    {
        public int Quantity { get; set; }

        [MaxLength(20)]
        public string? Size { get; set; }

        [MaxLength(50)]
        public string? Color { get; set; }

        // Foreign keys
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        // Navigation properties
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; } = null!;
    }
}
