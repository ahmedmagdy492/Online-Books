using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_books.Data.Migrations
{
    public partial class movedLangCateRelationToBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_LanguageCategories_LangCategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_LangCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LangCategoryId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "RealLanguageCategoryId",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LangCategoryId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RealLanguageCategoryId",
                table: "Categories",
                column: "RealLanguageCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LangCategoryId",
                table: "Books",
                column: "LangCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_LanguageCategories_LangCategoryId",
                table: "Books",
                column: "LangCategoryId",
                principalTable: "LanguageCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_LanguageCategories_RealLanguageCategoryId",
                table: "Categories",
                column: "RealLanguageCategoryId",
                principalTable: "LanguageCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_LanguageCategories_LangCategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_LanguageCategories_RealLanguageCategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_RealLanguageCategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_LangCategoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "RealLanguageCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LangCategoryId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "LangCategoryId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LangCategoryId",
                table: "Categories",
                column: "LangCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_LanguageCategories_LangCategoryId",
                table: "Categories",
                column: "LangCategoryId",
                principalTable: "LanguageCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
