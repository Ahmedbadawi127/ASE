using Microsoft.EntityFrameworkCore.Migrations;

namespace Shipping.Infrastructure.Migrations
{
    public partial class deliverymanstatesprices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DeliveryPrice",
                table: "DeliveryMenStates",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DeliveryMenStates",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryPrice",
                table: "DeliveryMenStates");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DeliveryMenStates");
        }
    }
}
