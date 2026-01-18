using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FIt3d.DAL.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }

        public UserRole Role { get; set; } = UserRole.Customer;

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }

    public enum UserRole
    {
        Customer = 0,
        Admin = 1,
        Staff = 2
    }
}
