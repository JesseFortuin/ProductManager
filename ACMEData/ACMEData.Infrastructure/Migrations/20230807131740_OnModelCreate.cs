using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ACMEData.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OnModelCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Price", "ProductCode", "ProductName", "ReleaseData", "StarRating" },
                values: new object[,]
                {
                    { 1, "Leaf rake with 48-inch wooden handle.", 19.949999999999999, "GDN-0011", "Leaf Rake", "March 19, 2021", 3.2000000000000002 },
                    { 2, "15 gallon capacity rolling garden cart", 32.990000000000002, "GDN-0023", "Garden Cart", "March 18, 2021", 4.2000000000000002 },
                    { 5, "Curved claw steel hammer", 8.9000000000000004, "TBX-0048", "Hammer", "May 21, 2021", 4.7999999999999998 },
                    { 8, "15-inch steel blade hand saw", 11.550000000000001, "TBX-0022", "Saw", "May 15, 2021", 3.7000000000000002 },
                    { 10, "Standard two-button video game controller", 35.950000000000003, "GMG-0042", "Video Game Controller", "October 15, 2020", 4.5999999999999996 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);
        }
    }
}
