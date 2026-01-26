using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FIt3d.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_Fit3dSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "fit3d");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "fit3d");

            migrationBuilder.RenameTable(
                name: "ProductSizes",
                newName: "ProductSizes",
                newSchema: "fit3d");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "fit3d");

            migrationBuilder.RenameTable(
                name: "ProductColors",
                newName: "ProductColors",
                newSchema: "fit3d");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "fit3d");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItems",
                newSchema: "fit3d");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "fit3d");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "CartItems",
                newSchema: "fit3d");

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "DisplayOrder", "ImageUrl", "IsActive", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Comfortable and stylish t-shirts for everyday wear", 1, "https://example.com/images/categories/tshirts.jpg", true, false, "T-Shirts", null },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Quality pants and trousers for all occasions", 2, "https://example.com/images/categories/pants.jpg", true, false, "Pants", null },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Elegant dresses for women", 3, "https://example.com/images/categories/dresses.jpg", true, false, "Dresses", null },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fashion accessories to complete your look", 4, "https://example.com/images/categories/accessories.jpg", true, false, "Accessories", null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FullName", "IsActive", "IsDeleted", "PasswordHash", "Phone", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "123 Admin Street, Ho Chi Minh City", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@fit3d.com", "Admin User", true, false, "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop", "0901234567", 1, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "456 Customer Lane, Ha Noi", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "nguyenvana@gmail.com", "Nguyen Van A", true, false, "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop", "0912345678", 0, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "789 Shopping Street, Da Nang", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "tranthib@gmail.com", "Tran Thi B", true, false, "AQAAAAIAAYagAAAAEJ8g1234567890abcdefghijklmnop", "0923456789", 0, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "DeliveredAt", "DiscountAmount", "IsDeleted", "Note", "OrderNumber", "PaymentMethod", "PaymentStatus", "ReceiverName", "ReceiverPhone", "ShippedAt", "ShippingAddress", "ShippingFee", "Status", "TotalAmount", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("aaaa1111-1111-1111-1111-111111111111"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), 50000m, false, "Please call before delivery", "ORD-2024-0001", "COD", 1, "Nguyen Van A", "0912345678", new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc), "456 Customer Lane, Ha Noi", 30000m, 4, 798000m, null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("bbbb2222-2222-2222-2222-222222222222"), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, false, null, "ORD-2024-0002", "VNPay", 1, "Tran Thi B", "0923456789", null, "789 Shopping Street, Da Nang", 0m, 2, 1130000m, null, new Guid("33333333-3333-3333-3333-333333333333") }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedAt", "Description", "ImageUrl", "IsActive", "IsDeleted", "IsFeatured", "Name", "Price", "SKU", "SalePrice", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-aaaa-1111-aaaa-111111111111"), "Fit3D", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "A timeless classic cotton t-shirt with a comfortable fit. Perfect for casual wear.", "https://example.com/images/products/tshirt-classic.jpg", true, false, true, "Classic Cotton T-Shirt", 299000m, "TS-001", 249000m, 100, null },
                    { new Guid("22222222-aaaa-2222-aaaa-222222222222"), "Fit3D", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Elegant polo shirt made from premium cotton blend. Great for smart casual occasions.", "https://example.com/images/products/polo-premium.jpg", true, false, true, "Premium Polo Shirt", 450000m, "TS-002", null, 75, null },
                    { new Guid("33333333-bbbb-3333-bbbb-333333333333"), "Fit3D Denim", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Modern slim fit jeans with stretch for ultimate comfort. Available in multiple washes.", "https://example.com/images/products/jeans-slim.jpg", true, false, false, "Slim Fit Jeans", 650000m, "PT-001", 550000m, 50, null },
                    { new Guid("44444444-cccc-4444-cccc-444444444444"), "Fit3D Ladies", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Beautiful floral print summer dress. Light and breezy fabric perfect for warm days.", "https://example.com/images/products/dress-floral.jpg", true, false, true, "Floral Summer Dress", 780000m, "DR-001", 680000m, 30, null },
                    { new Guid("55555555-dddd-5555-dddd-555555555555"), "Fit3D Accessories", new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Genuine leather belt with classic buckle. Perfect accessory for any outfit.", "https://example.com/images/products/belt-leather.jpg", true, false, false, "Leather Belt", 350000m, "AC-001", null, 60, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "CartItems",
                columns: new[] { "Id", "Color", "CreatedAt", "IsDeleted", "ProductId", "Quantity", "Size", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("ca111111-1111-1111-1111-111111111111"), "Light Blue", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), 1, "L", null, new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("ca222222-2222-2222-2222-222222222222"), "Black", new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), 3, "S", null, new Guid("33333333-3333-3333-3333-333333333333") }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "OrderItems",
                columns: new[] { "Id", "Color", "CreatedAt", "IsDeleted", "OrderId", "ProductId", "Quantity", "Size", "TotalPrice", "UnitPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("01111111-1111-1111-1111-111111111111"), "White", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("aaaa1111-1111-1111-1111-111111111111"), new Guid("11111111-aaaa-1111-aaaa-111111111111"), 2, "M", 498000m, 249000m, null },
                    { new Guid("02222222-2222-2222-2222-222222222222"), "Brown", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("aaaa1111-1111-1111-1111-111111111111"), new Guid("55555555-dddd-5555-dddd-555555555555"), 1, null, 350000m, 350000m, null },
                    { new Guid("03333333-3333-3333-3333-333333333333"), "Blue Wash", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("bbbb2222-2222-2222-2222-222222222222"), new Guid("33333333-bbbb-3333-bbbb-333333333333"), 1, "30", 550000m, 550000m, null },
                    { new Guid("04444444-4444-4444-4444-444444444444"), "Floral Pink", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("bbbb2222-2222-2222-2222-222222222222"), new Guid("44444444-cccc-4444-cccc-444444444444"), 1, "M", 680000m, 680000m, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "ProductColors",
                columns: new[] { "Id", "ColorCode", "ColorName", "CreatedAt", "ImageUrl", "IsDeleted", "ProductId", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-2222-1111-1111-111111111111"), "#4169E1", "Blue Wash", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("33333333-bbbb-3333-bbbb-333333333333"), 25, null },
                    { new Guid("22222222-2222-1111-1111-111111111111"), "#191970", "Dark Wash", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("33333333-bbbb-3333-bbbb-333333333333"), 25, null },
                    { new Guid("33333333-2222-1111-1111-111111111111"), "#FFB6C1", "Floral Pink", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("44444444-cccc-4444-cccc-444444444444"), 15, null },
                    { new Guid("44444444-2222-1111-1111-111111111111"), "#87CEEB", "Floral Blue", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("44444444-cccc-4444-cccc-444444444444"), 15, null },
                    { new Guid("55555555-2222-1111-1111-111111111111"), "#8B4513", "Brown", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("55555555-dddd-5555-dddd-555555555555"), 30, null },
                    { new Guid("66666666-2222-1111-1111-111111111111"), "#000000", "Black", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("55555555-dddd-5555-dddd-555555555555"), 30, null },
                    { new Guid("e1111111-1111-1111-1111-111111111111"), "#FFFFFF", "White", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), 35, null },
                    { new Guid("e2222222-2222-2222-2222-222222222222"), "#000000", "Black", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), 35, null },
                    { new Guid("e3333333-3333-3333-3333-333333333333"), "#000080", "Navy Blue", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), 30, null },
                    { new Guid("f1111111-1111-1111-1111-111111111111"), "#FFFFFF", "White", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), 25, null },
                    { new Guid("f2222222-2222-2222-2222-222222222222"), "#ADD8E6", "Light Blue", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), 25, null },
                    { new Guid("f3333333-3333-3333-3333-333333333333"), "#FFC0CB", "Pink", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), 25, null }
                });

            migrationBuilder.InsertData(
                schema: "fit3d",
                table: "ProductSizes",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "ProductId", "Size", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), "S", 25, null },
                    { new Guid("a2222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), "M", 30, null },
                    { new Guid("a3333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), "L", 25, null },
                    { new Guid("a4444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("11111111-aaaa-1111-aaaa-111111111111"), "XL", 20, null },
                    { new Guid("b1111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), "S", 20, null },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), "M", 25, null },
                    { new Guid("b3333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("22222222-aaaa-2222-aaaa-222222222222"), "L", 20, null },
                    { new Guid("c1111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("33333333-bbbb-3333-bbbb-333333333333"), "28", 10, null },
                    { new Guid("c2222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("33333333-bbbb-3333-bbbb-333333333333"), "30", 15, null },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("33333333-bbbb-3333-bbbb-333333333333"), "32", 15, null },
                    { new Guid("c4444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("33333333-bbbb-3333-bbbb-333333333333"), "34", 10, null },
                    { new Guid("d1111111-1111-1111-1111-111111111111"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("44444444-cccc-4444-cccc-444444444444"), "S", 10, null },
                    { new Guid("d2222222-2222-2222-2222-222222222222"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("44444444-cccc-4444-cccc-444444444444"), "M", 12, null },
                    { new Guid("d3333333-3333-3333-3333-333333333333"), new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), false, new Guid("44444444-cccc-4444-cccc-444444444444"), "L", 8, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("ca111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("ca222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("01111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("02222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("03333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("04444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("11111111-2222-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("33333333-2222-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("44444444-2222-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("55555555-2222-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("66666666-2222-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("e1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("e2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("e3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("f1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("f2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("f3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("c1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("c2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("c4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("d1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("d2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("d3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("aaaa1111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("bbbb2222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-aaaa-1111-aaaa-111111111111"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-aaaa-2222-aaaa-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-bbbb-3333-bbbb-333333333333"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-cccc-4444-cccc-444444444444"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("55555555-dddd-5555-dddd-555555555555"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                schema: "fit3d",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "fit3d",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "ProductSizes",
                schema: "fit3d",
                newName: "ProductSizes");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "fit3d",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ProductColors",
                schema: "fit3d",
                newName: "ProductColors");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "fit3d",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                schema: "fit3d",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "fit3d",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "CartItems",
                schema: "fit3d",
                newName: "CartItems");
        }
    }
}
