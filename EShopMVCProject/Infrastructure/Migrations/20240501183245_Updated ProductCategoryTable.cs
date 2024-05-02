using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProductCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_CategoryVariation_CategoryVariationId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_CategoryVariationId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "CategoryVariationId",
                table: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "CategoryVariationProductCategory",
                columns: table => new
                {
                    CategoryVariationId = table.Column<int>(type: "int", nullable: false),
                    ProductCategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryVariationProductCategory", x => new { x.CategoryVariationId, x.ProductCategoriesId });
                    table.ForeignKey(
                        name: "FK_CategoryVariationProductCategory_CategoryVariation_CategoryVariationId",
                        column: x => x.CategoryVariationId,
                        principalTable: "CategoryVariation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryVariationProductCategory_ProductCategories_ProductCategoriesId",
                        column: x => x.ProductCategoriesId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryVariationProductCategory_ProductCategoriesId",
                table: "CategoryVariationProductCategory",
                column: "ProductCategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryVariationProductCategory");

            migrationBuilder.AddColumn<int>(
                name: "CategoryVariationId",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryVariationId",
                table: "ProductCategories",
                column: "CategoryVariationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_CategoryVariation_CategoryVariationId",
                table: "ProductCategories",
                column: "CategoryVariationId",
                principalTable: "CategoryVariation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
