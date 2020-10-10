using Microsoft.EntityFrameworkCore.Migrations;

namespace Heartcooking.API.Migrations
{
    public partial class SaltAmountInProductNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Salt",
                table: "Products",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Salt",
                table: "Products",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
