using Microsoft.EntityFrameworkCore.Migrations;

namespace Shipping.Infrastructure.Migrations
{
    public partial class dbsetstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryMenStates_State_StateId",
                table: "DeliveryMenStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "State");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryMenStates_States_StateId",
                table: "DeliveryMenStates",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryMenStates_States_StateId",
                table: "DeliveryMenStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "State",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryMenStates_State_StateId",
                table: "DeliveryMenStates",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
