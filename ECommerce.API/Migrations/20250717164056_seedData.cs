using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "IsActive", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Description for Product 1", "https://example.com/product1.jpg", false, "Product 1", 10.99m, 0 },
                    { 2, "Description for Product 2", "https://example.com/product2.jpg", true, "Product 2", 20.99m, 100 },
                    { 3, "Description for Product 3", "https://example.com/product3.jpg", true, "Product 3", 30.99m, 200 },
                    { 4, "Description for Product 4", "https://example.com/product4.jpg", true, "Product 4", 40.99m, 400 },
                    { 5, "Description for Product 5", "https://example.com/product5.jpg", true, "Product 5", 50.99m, 800 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
