using FIt3d.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIt3d.DAL.Data
{
    public class Fit3dDbContext : DbContext
    {
        public Fit3dDbContext(DbContextOptions<Fit3dDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set default schema to fit3d
            modelBuilder.HasDefaultSchema("fit3d");

            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // Category configuration
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            // Product configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.SalePrice).HasColumnType("decimal(18,2)");
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ProductSize configuration
            modelBuilder.Entity<ProductSize>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Size).IsRequired().HasMaxLength(20);
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ProductColor configuration
            modelBuilder.Entity<ProductColor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ColorName).IsRequired().HasMaxLength(50);
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Order configuration
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OrderNumber).IsRequired().HasMaxLength(50);
                entity.HasIndex(e => e.OrderNumber).IsUnique();
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ShippingFee).HasColumnType("decimal(18,2)");
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // OrderItem configuration
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // CartItem configuration
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasQueryFilter(e => !e.IsDeleted);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.CartItems)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed Data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Users
            var adminId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var customerId1 = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var customerId2 = Guid.Parse("33333333-3333-3333-3333-333333333333");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    FullName = "Admin User",
                    Email = "admin@fit3d.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop", // Placeholder hash
                    Phone = "0901234567",
                    Address = "123 Admin Street, Ho Chi Minh City",
                    Role = UserRole.Admin,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new User
                {
                    Id = customerId1,
                    FullName = "Nguyen Van A",
                    Email = "nguyenvana@gmail.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop",
                    Phone = "0912345678",
                    Address = "456 Customer Lane, Ha Noi",
                    Role = UserRole.Customer,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new User
                {
                    Id = customerId2,
                    FullName = "Tran Thi B",
                    Email = "tranthib@gmail.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop",
                    Phone = "0923456789",
                    Address = "789 Shopping Street, Da Nang",
                    Role = UserRole.Customer,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Seed Categories
            var categoryTshirt = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var categoryPants = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
            var categoryDress = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");
            var categoryAccessories = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = categoryTshirt,
                    Name = "T-Shirts",
                    Description = "Comfortable and stylish t-shirts for everyday wear",
                    ImageUrl = "https://example.com/images/categories/tshirts.jpg",
                    DisplayOrder = 1,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = categoryPants,
                    Name = "Pants",
                    Description = "Quality pants and trousers for all occasions",
                    ImageUrl = "https://example.com/images/categories/pants.jpg",
                    DisplayOrder = 2,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = categoryDress,
                    Name = "Dresses",
                    Description = "Elegant dresses for women",
                    ImageUrl = "https://example.com/images/categories/dresses.jpg",
                    DisplayOrder = 3,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Category
                {
                    Id = categoryAccessories,
                    Name = "Accessories",
                    Description = "Fashion accessories to complete your look",
                    ImageUrl = "https://example.com/images/categories/accessories.jpg",
                    DisplayOrder = 4,
                    IsActive = true,
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Seed Products
            var product1 = Guid.Parse("11111111-aaaa-1111-aaaa-111111111111");
            var product2 = Guid.Parse("22222222-aaaa-2222-aaaa-222222222222");
            var product3 = Guid.Parse("33333333-bbbb-3333-bbbb-333333333333");
            var product4 = Guid.Parse("44444444-cccc-4444-cccc-444444444444");
            var product5 = Guid.Parse("55555555-dddd-5555-dddd-555555555555");

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = product1,
                    Name = "Classic Cotton T-Shirt",
                    Description = "A timeless classic cotton t-shirt with a comfortable fit. Perfect for casual wear.",
                    Price = 299000m,
                    SalePrice = 249000m,
                    SKU = "TS-001",
                    Brand = "Fit3D",
                    ImageUrl = "https://example.com/images/products/tshirt-classic.jpg",
                    StockQuantity = 100,
                    IsActive = true,
                    IsFeatured = true,
                    CategoryId = categoryTshirt,
                    CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc)
                },
                new Product
                {
                    Id = product2,
                    Name = "Premium Polo Shirt",
                    Description = "Elegant polo shirt made from premium cotton blend. Great for smart casual occasions.",
                    Price = 450000m,
                    SalePrice = null,
                    SKU = "TS-002",
                    Brand = "Fit3D",
                    ImageUrl = "https://example.com/images/products/polo-premium.jpg",
                    StockQuantity = 75,
                    IsActive = true,
                    IsFeatured = true,
                    CategoryId = categoryTshirt,
                    CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc)
                },
                new Product
                {
                    Id = product3,
                    Name = "Slim Fit Jeans",
                    Description = "Modern slim fit jeans with stretch for ultimate comfort. Available in multiple washes.",
                    Price = 650000m,
                    SalePrice = 550000m,
                    SKU = "PT-001",
                    Brand = "Fit3D Denim",
                    ImageUrl = "https://example.com/images/products/jeans-slim.jpg",
                    StockQuantity = 50,
                    IsActive = true,
                    IsFeatured = false,
                    CategoryId = categoryPants,
                    CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new Product
                {
                    Id = product4,
                    Name = "Floral Summer Dress",
                    Description = "Beautiful floral print summer dress. Light and breezy fabric perfect for warm days.",
                    Price = 780000m,
                    SalePrice = 680000m,
                    SKU = "DR-001",
                    Brand = "Fit3D Ladies",
                    ImageUrl = "https://example.com/images/products/dress-floral.jpg",
                    StockQuantity = 30,
                    IsActive = true,
                    IsFeatured = true,
                    CategoryId = categoryDress,
                    CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Product
                {
                    Id = product5,
                    Name = "Leather Belt",
                    Description = "Genuine leather belt with classic buckle. Perfect accessory for any outfit.",
                    Price = 350000m,
                    SalePrice = null,
                    SKU = "AC-001",
                    Brand = "Fit3D Accessories",
                    ImageUrl = "https://example.com/images/products/belt-leather.jpg",
                    StockQuantity = 60,
                    IsActive = true,
                    IsFeatured = false,
                    CategoryId = categoryAccessories,
                    CreatedAt = new DateTime(2024, 2, 5, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Seed Product Sizes
            modelBuilder.Entity<ProductSize>().HasData(
                // T-Shirt sizes
                new ProductSize { Id = Guid.Parse("a1111111-1111-1111-1111-111111111111"), ProductId = product1, Size = "S", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("a2222222-2222-2222-2222-222222222222"), ProductId = product1, Size = "M", StockQuantity = 30, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("a3333333-3333-3333-3333-333333333333"), ProductId = product1, Size = "L", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("a4444444-4444-4444-4444-444444444444"), ProductId = product1, Size = "XL", StockQuantity = 20, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                // Polo shirt sizes
                new ProductSize { Id = Guid.Parse("b1111111-1111-1111-1111-111111111111"), ProductId = product2, Size = "S", StockQuantity = 20, CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("b2222222-2222-2222-2222-222222222222"), ProductId = product2, Size = "M", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("b3333333-3333-3333-3333-333333333333"), ProductId = product2, Size = "L", StockQuantity = 20, CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                // Jeans sizes
                new ProductSize { Id = Guid.Parse("c1111111-1111-1111-1111-111111111111"), ProductId = product3, Size = "28", StockQuantity = 10, CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("c2222222-2222-2222-2222-222222222222"), ProductId = product3, Size = "30", StockQuantity = 15, CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("c3333333-3333-3333-3333-333333333333"), ProductId = product3, Size = "32", StockQuantity = 15, CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("c4444444-4444-4444-4444-444444444444"), ProductId = product3, Size = "34", StockQuantity = 10, CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                // Dress sizes
                new ProductSize { Id = Guid.Parse("d1111111-1111-1111-1111-111111111111"), ProductId = product4, Size = "S", StockQuantity = 10, CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("d2222222-2222-2222-2222-222222222222"), ProductId = product4, Size = "M", StockQuantity = 12, CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                new ProductSize { Id = Guid.Parse("d3333333-3333-3333-3333-333333333333"), ProductId = product4, Size = "L", StockQuantity = 8, CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc) }
            );

            // Seed Product Colors
            modelBuilder.Entity<ProductColor>().HasData(
                // T-Shirt colors
                new ProductColor { Id = Guid.Parse("e1111111-1111-1111-1111-111111111111"), ProductId = product1, ColorName = "White", ColorCode = "#FFFFFF", StockQuantity = 35, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("e2222222-2222-2222-2222-222222222222"), ProductId = product1, ColorName = "Black", ColorCode = "#000000", StockQuantity = 35, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("e3333333-3333-3333-3333-333333333333"), ProductId = product1, ColorName = "Navy Blue", ColorCode = "#000080", StockQuantity = 30, CreatedAt = new DateTime(2024, 1, 5, 0, 0, 0, DateTimeKind.Utc) },
                // Polo colors
                new ProductColor { Id = Guid.Parse("f1111111-1111-1111-1111-111111111111"), ProductId = product2, ColorName = "White", ColorCode = "#FFFFFF", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("f2222222-2222-2222-2222-222222222222"), ProductId = product2, ColorName = "Light Blue", ColorCode = "#ADD8E6", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("f3333333-3333-3333-3333-333333333333"), ProductId = product2, ColorName = "Pink", ColorCode = "#FFC0CB", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc) },
                // Jeans colors
                new ProductColor { Id = Guid.Parse("11111111-2222-1111-1111-111111111111"), ProductId = product3, ColorName = "Blue Wash", ColorCode = "#4169E1", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("22222222-2222-1111-1111-111111111111"), ProductId = product3, ColorName = "Dark Wash", ColorCode = "#191970", StockQuantity = 25, CreatedAt = new DateTime(2024, 1, 15, 0, 0, 0, DateTimeKind.Utc) },
                // Dress colors
                new ProductColor { Id = Guid.Parse("33333333-2222-1111-1111-111111111111"), ProductId = product4, ColorName = "Floral Pink", ColorCode = "#FFB6C1", StockQuantity = 15, CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("44444444-2222-1111-1111-111111111111"), ProductId = product4, ColorName = "Floral Blue", ColorCode = "#87CEEB", StockQuantity = 15, CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                // Belt colors
                new ProductColor { Id = Guid.Parse("55555555-2222-1111-1111-111111111111"), ProductId = product5, ColorName = "Brown", ColorCode = "#8B4513", StockQuantity = 30, CreatedAt = new DateTime(2024, 2, 5, 0, 0, 0, DateTimeKind.Utc) },
                new ProductColor { Id = Guid.Parse("66666666-2222-1111-1111-111111111111"), ProductId = product5, ColorName = "Black", ColorCode = "#000000", StockQuantity = 30, CreatedAt = new DateTime(2024, 2, 5, 0, 0, 0, DateTimeKind.Utc) }
            );

            // Seed Orders
            var order1 = Guid.Parse("aaaa1111-1111-1111-1111-111111111111");
            var order2 = Guid.Parse("bbbb2222-2222-2222-2222-222222222222");

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = order1,
                    OrderNumber = "ORD-2024-0001",
                    TotalAmount = 798000m,
                    DiscountAmount = 50000m,
                    ShippingFee = 30000m,
                    Status = OrderStatus.Delivered,
                    PaymentStatus = PaymentStatus.Paid,
                    PaymentMethod = "COD",
                    ShippingAddress = "456 Customer Lane, Ha Noi",
                    ReceiverName = "Nguyen Van A",
                    ReceiverPhone = "0912345678",
                    Note = "Please call before delivery",
                    UserId = customerId1,
                    ShippedAt = new DateTime(2024, 2, 3, 0, 0, 0, DateTimeKind.Utc),
                    DeliveredAt = new DateTime(2024, 2, 5, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Order
                {
                    Id = order2,
                    OrderNumber = "ORD-2024-0002",
                    TotalAmount = 1130000m,
                    DiscountAmount = null,
                    ShippingFee = 0m,
                    Status = OrderStatus.Processing,
                    PaymentStatus = PaymentStatus.Paid,
                    PaymentMethod = "VNPay",
                    ShippingAddress = "789 Shopping Street, Da Nang",
                    ReceiverName = "Tran Thi B",
                    ReceiverPhone = "0923456789",
                    Note = null,
                    UserId = customerId2,
                    ShippedAt = null,
                    DeliveredAt = null,
                    CreatedAt = new DateTime(2024, 2, 10, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Seed Order Items
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = Guid.Parse("01111111-1111-1111-1111-111111111111"),
                    OrderId = order1,
                    ProductId = product1,
                    Quantity = 2,
                    UnitPrice = 249000m,
                    TotalPrice = 498000m,
                    Size = "M",
                    Color = "White",
                    CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new OrderItem
                {
                    Id = Guid.Parse("02222222-2222-2222-2222-222222222222"),
                    OrderId = order1,
                    ProductId = product5,
                    Quantity = 1,
                    UnitPrice = 350000m,
                    TotalPrice = 350000m,
                    Size = null,
                    Color = "Brown",
                    CreatedAt = new DateTime(2024, 2, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new OrderItem
                {
                    Id = Guid.Parse("03333333-3333-3333-3333-333333333333"),
                    OrderId = order2,
                    ProductId = product3,
                    Quantity = 1,
                    UnitPrice = 550000m,
                    TotalPrice = 550000m,
                    Size = "30",
                    Color = "Blue Wash",
                    CreatedAt = new DateTime(2024, 2, 10, 0, 0, 0, DateTimeKind.Utc)
                },
                new OrderItem
                {
                    Id = Guid.Parse("04444444-4444-4444-4444-444444444444"),
                    OrderId = order2,
                    ProductId = product4,
                    Quantity = 1,
                    UnitPrice = 680000m,
                    TotalPrice = 680000m,
                    Size = "M",
                    Color = "Floral Pink",
                    CreatedAt = new DateTime(2024, 2, 10, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Seed Cart Items
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    Id = Guid.Parse("ca111111-1111-1111-1111-111111111111"),
                    UserId = customerId1,
                    ProductId = product2,
                    Quantity = 1,
                    Size = "L",
                    Color = "Light Blue",
                    CreatedAt = new DateTime(2024, 2, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new CartItem
                {
                    Id = Guid.Parse("ca222222-2222-2222-2222-222222222222"),
                    UserId = customerId2,
                    ProductId = product1,
                    Quantity = 3,
                    Size = "S",
                    Color = "Black",
                    CreatedAt = new DateTime(2024, 2, 16, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
