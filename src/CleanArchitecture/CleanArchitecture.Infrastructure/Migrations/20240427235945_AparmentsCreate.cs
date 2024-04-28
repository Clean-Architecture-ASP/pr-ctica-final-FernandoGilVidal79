using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AparmentsCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apartments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_street = table.Column<string>(type: "text", nullable: true),
                    address_departure = table.Column<string>(type: "text", nullable: true),
                    address_country = table.Column<string>(type: "text", nullable: true),
                    address_province = table.Column<string>(type: "text", nullable: true),
                    address_city = table.Column<string>(type: "text", nullable: true),
                    price_quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    price_currency_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_apartments", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "fk_rents_apartments_apartment_id",
                table: "rents",
                column: "vehicule_id",
                principalTable: "apartments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_rents_apartments_apartment_id",
                table: "rents");

            migrationBuilder.DropTable(
                name: "apartments");
        }
    }
}
