using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaManagement.Migrations
{
    /// <inheritdoc />
    public partial class seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "PizzaName", "Topping1Id", "Topping2Id", "Topping3Id" },
                values: new object[,]
                {
                    { 1, "Extra Pepperoni", 1, 1, 1 },
                    { 2, "Meat Lovers", 1, 1, 2 },
                    { 3, "Special", 1, 3, 4 },
                    { 4, "Mushroom", 3, 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
