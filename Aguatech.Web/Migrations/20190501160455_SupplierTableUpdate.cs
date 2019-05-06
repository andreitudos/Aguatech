using Microsoft.EntityFrameworkCore.Migrations;

namespace Aguatech.Web.Migrations
{
    public partial class SupplierTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Supplier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Supplier",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VAT",
                table: "Supplier",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Brand",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brand_SupplierId",
                table: "Brand",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_Supplier_SupplierId",
                table: "Brand",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_Supplier_SupplierId",
                table: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Brand_SupplierId",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Brand");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Supplier",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
