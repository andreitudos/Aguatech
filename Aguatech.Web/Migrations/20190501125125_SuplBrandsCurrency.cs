using Microsoft.EntityFrameworkCore.Migrations;

namespace Aguatech.Web.Migrations
{
    public partial class SuplBrandsCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Simbol",
                table: "Currencies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Simbol",
                table: "Currencies");
        }
    }
}
