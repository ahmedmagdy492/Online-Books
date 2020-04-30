using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_books.Data.Migrations
{
    public partial class addedImgUrlPropToBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Books");
        }
    }
}
