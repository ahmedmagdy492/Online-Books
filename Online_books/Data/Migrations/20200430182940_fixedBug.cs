using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_books.Data.Migrations
{
    public partial class fixedBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_LanguageCategories_RealLanguageCategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_RealLanguageCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RealLanguageCategoryId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RealLanguageCategoryId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RealLanguageCategoryId",
                table: "Categories",
                column: "RealLanguageCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_LanguageCategories_RealLanguageCategoryId",
                table: "Categories",
                column: "RealLanguageCategoryId",
                principalTable: "LanguageCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
