using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buoi17_First.Migrations
{
    public partial class UsernameUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserName",
                table: "Customer",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_UserName",
                table: "Customer");
        }
    }
}
