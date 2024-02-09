using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaManagement.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToppingName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topping1Id = table.Column<int>(type: "int", nullable: true),
                    Topping2Id = table.Column<int>(type: "int", nullable: true),
                    Topping3Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_Toppings_Topping1Id",
                        column: x => x.Topping1Id,
                        principalTable: "Toppings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pizzas_Toppings_Topping2Id",
                        column: x => x.Topping2Id,
                        principalTable: "Toppings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pizzas_Toppings_Topping3Id",
                        column: x => x.Topping3Id,
                        principalTable: "Toppings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_Topping1Id",
                table: "Pizzas",
                column: "Topping1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_Topping2Id",
                table: "Pizzas",
                column: "Topping2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_Topping3Id",
                table: "Pizzas",
                column: "Topping3Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Toppings");
        }
    }
}
