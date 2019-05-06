using Microsoft.EntityFrameworkCore.Migrations;

namespace Aguatech.Web.Migrations
{
    public partial class CustTypeDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountRate",
                table: "CustomerType",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountRate",
                table: "CustomerType");
        }
    }
}
