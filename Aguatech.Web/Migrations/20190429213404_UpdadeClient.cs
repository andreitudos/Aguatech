using Microsoft.EntityFrameworkCore.Migrations;

namespace Aguatech.Web.Migrations
{
    public partial class UpdadeClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Customers");
        }
    }
}
