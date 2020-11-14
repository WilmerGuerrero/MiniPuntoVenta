using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class Scotiabank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_procesoFactura",
                table: "procesoFactura");

            migrationBuilder.AddColumn<int>(
                name: "Clienteid",
                table: "procesoFactura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_procesoFactura",
                table: "procesoFactura",
                columns: new[] { "Facturaid", "Productoid", "Clienteid" });

            migrationBuilder.CreateIndex(
                name: "IX_procesoFactura_Clienteid",
                table: "procesoFactura",
                column: "Clienteid");

            migrationBuilder.AddForeignKey(
                name: "FK_procesoFactura_Cliente_Clienteid",
                table: "procesoFactura",
                column: "Clienteid",
                principalTable: "Cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_procesoFactura_Cliente_Clienteid",
                table: "procesoFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_procesoFactura",
                table: "procesoFactura");

            migrationBuilder.DropIndex(
                name: "IX_procesoFactura_Clienteid",
                table: "procesoFactura");

            migrationBuilder.DropColumn(
                name: "Clienteid",
                table: "procesoFactura");

            migrationBuilder.AddPrimaryKey(
                name: "PK_procesoFactura",
                table: "procesoFactura",
                columns: new[] { "Facturaid", "Productoid" });
        }
    }
}
