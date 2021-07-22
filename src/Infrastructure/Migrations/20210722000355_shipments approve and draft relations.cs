using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Shipping.Infrastructure.Migrations
{
    public partial class shipmentsapproveanddraftrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_DeliveryMen_DeliveryManId",
                table: "Shipments");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryMen",
                table: "DeliveryMen");

            migrationBuilder.RenameTable(
                name: "DeliveryMen",
                newName: "DeliveryMan");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryManId",
                table: "Shipments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Shipments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryMan",
                table: "DeliveryMan",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ApprovedShipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApprovedNotes = table.Column<string>(type: "text", nullable: true),
                    DeliveryManId = table.Column<int>(type: "integer", nullable: false),
                    DeliveryManName = table.Column<string>(type: "text", nullable: true),
                    ShipmentRef = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedShipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovedShipments_Shipments_ShipmentRef",
                        column: x => x.ShipmentRef,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedShipments_ShipmentRef",
                table: "ApprovedShipments",
                column: "ShipmentRef",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_DeliveryMan_DeliveryManId",
                table: "Shipments",
                column: "DeliveryManId",
                principalTable: "DeliveryMan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_DeliveryMan_DeliveryManId",
                table: "Shipments");

            migrationBuilder.DropTable(
                name: "ApprovedShipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryMan",
                table: "DeliveryMan");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Shipments");

            migrationBuilder.RenameTable(
                name: "DeliveryMan",
                newName: "DeliveryMen");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryManId",
                table: "Shipments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryMen",
                table: "DeliveryMen",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    NameAr = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    SId = table.Column<Guid>(type: "uuid", maxLength: 128, nullable: false),
                    UserTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_DeliveryMen_DeliveryManId",
                table: "Shipments",
                column: "DeliveryManId",
                principalTable: "DeliveryMen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
