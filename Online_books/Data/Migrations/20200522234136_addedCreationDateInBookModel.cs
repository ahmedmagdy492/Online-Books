using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_books.Data.Migrations
{
    public partial class addedCreationDateInBookModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18af6743-1f63-42a6-8adb-65cdd7dcec33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd87e1bd-ca13-426a-8a6c-7429330d84be");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23b4a7e1-765d-4e59-8419-fc49f449b7cb", "021162ab-bbf4-4eaf-b956-30702b3c67d9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fa96c1a6-85a2-4c93-ac79-d683d8f961a8", "ea0ee277-c68d-45fb-847d-e39dd9e2e15a", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23b4a7e1-765d-4e59-8419-fc49f449b7cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa96c1a6-85a2-4c93-ac79-d683d8f961a8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd87e1bd-ca13-426a-8a6c-7429330d84be", "9d333578-8803-4fd1-8e2f-39e99761350b", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18af6743-1f63-42a6-8adb-65cdd7dcec33", "97093b09-01db-47a3-89f8-a35c365490a8", "Admin", null });
        }
    }
}
