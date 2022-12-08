using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodWebAPI.Migrations
{
    public partial class newFoodMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipies",
                columns: table => new
                {
                    RecipieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeToCook = table.Column<double>(type: "float", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isVeganFood = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipies", x => x.RecipieId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipieId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipies_RecipieId",
                        column: x => x.RecipieId,
                        principalTable: "Recipies",
                        principalColumn: "RecipieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Recipies",
                columns: new[] { "RecipieId", "Method", "Name", "TimeToCook", "isVeganFood" },
                values: new object[] { 1, "Boiling", "Jollof", 185.33333333333334, false });

            migrationBuilder.InsertData(
                table: "Recipies",
                columns: new[] { "RecipieId", "Method", "Name", "TimeToCook", "isVeganFood" },
                values: new object[] { 2, "Boiling", "Ampesi", 59.75, true });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Name", "Quantity", "RecipieId", "Unit" },
                values: new object[,]
                {
                    { 1, "Rice", 2m, 1, "grams" },
                    { 2, "Tomatoes", 10m, 1, "Sachet" },
                    { 3, "Yam", 2m, 2, "Tuber" },
                    { 4, "Plantain", 5m, 2, "Sticks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipieId",
                table: "Ingredients",
                column: "RecipieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Recipies");
        }
    }
}
