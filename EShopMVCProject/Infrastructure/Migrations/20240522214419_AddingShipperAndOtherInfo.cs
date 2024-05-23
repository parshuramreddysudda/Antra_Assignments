using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingShipperAndOtherInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryVariationProductCategory");

            migrationBuilder.RenameColumn(
                name: "Parent_category_Id",
                table: "ProductCategories",
                newName: "ParentCategoryId");

            migrationBuilder.RenameColumn(
                name: "Variation_Name",
                table: "CategoryVariation",
                newName: "VariationName");

            migrationBuilder.RenameColumn(
                name: "Category_Id",
                table: "CategoryVariation",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductCategories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentCategoryId",
                table: "ProductCategories",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_CategoryVariation_ParentCategoryId",
                table: "ProductCategories",
                column: "ParentCategoryId",
                principalTable: "CategoryVariation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_CategoryVariation_ParentCategoryId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ParentCategoryId",
                table: "ProductCategories");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "ProductCategories",
                newName: "Parent_category_Id");

            migrationBuilder.RenameColumn(
                name: "VariationName",
                table: "CategoryVariation",
                newName: "Variation_Name");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryVariation",
                newName: "Category_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

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
    }
}
