using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIt3d.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add3DModelColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModelFilePath",
                schema: "fit3d",
                table: "Products",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviewModelPath",
                schema: "fit3d",
                table: "Products",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-aaaa-1111-aaaa-111111111111"),
                columns: new[] { "ModelFilePath", "PreviewModelPath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-aaaa-2222-aaaa-222222222222"),
                columns: new[] { "ModelFilePath", "PreviewModelPath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-bbbb-3333-bbbb-333333333333"),
                columns: new[] { "ModelFilePath", "PreviewModelPath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-cccc-4444-cccc-444444444444"),
                columns: new[] { "ModelFilePath", "PreviewModelPath" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "fit3d",
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("55555555-dddd-5555-dddd-555555555555"),
                columns: new[] { "ModelFilePath", "PreviewModelPath" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelFilePath",
                schema: "fit3d",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PreviewModelPath",
                schema: "fit3d",
                table: "Products");
        }
    }
}
