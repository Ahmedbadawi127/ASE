using Microsoft.EntityFrameworkCore.Migrations;

namespace Shipping.Infrastructure.Migrations
{
    public partial class fixdevnam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryMenStates_DeliveryMan_DeliveryManId",
                table: "DeliveryMenStates");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_DeliveryMan_DeliveryManId",
                table: "Shipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryMan",
                table: "DeliveryMan");

            migrationBuilder.RenameTable(
                name: "DeliveryMan",
                newName: "DeliveryMen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryMen",
                table: "DeliveryMen",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryMenStates_DeliveryMen_DeliveryManId",
                table: "DeliveryMenStates",
                column: "DeliveryManId",
                principalTable: "DeliveryMen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_DeliveryMen_DeliveryManId",
                table: "Shipments",
                column: "DeliveryManId",
                principalTable: "DeliveryMen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryMenStates_DeliveryMen_DeliveryManId",
                table: "DeliveryMenStates");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_DeliveryMen_DeliveryManId",
                table: "Shipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryMen",
                table: "DeliveryMen");

            migrationBuilder.RenameTable(
                name: "DeliveryMen",
                newName: "DeliveryMan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryMan",
                table: "DeliveryMan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryMenStates_DeliveryMan_DeliveryManId",
                table: "DeliveryMenStates",
                column: "DeliveryManId",
                principalTable: "DeliveryMan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_DeliveryMan_DeliveryManId",
                table: "Shipments",
                column: "DeliveryManId",
                principalTable: "DeliveryMan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
