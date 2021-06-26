using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Shipping.Infrastructure.Migrations
{
    public partial class deliveyma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryManId",
                table: "Shipments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeliveryMan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SId = table.Column<Guid>(type: "uuid", maxLength: 128, nullable: false),
                    NameAr = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    NameEn = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    GenderId = table.Column<int>(type: "integer", nullable: false),
                    GenderName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    Phone = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    Address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    StateId = table.Column<int>(type: "integer", nullable: false),
                    StateName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    CityName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMan", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_DeliveryManId",
                table: "Shipments",
                column: "DeliveryManId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_DeliveryMan_DeliveryManId",
                table: "Shipments",
                column: "DeliveryManId",
                principalTable: "DeliveryMan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_DeliveryMan_DeliveryManId",
                table: "Shipments");

            migrationBuilder.DropTable(
                name: "DeliveryMan");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_DeliveryManId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "DeliveryManId",
                table: "Shipments");
        }
    }
}
