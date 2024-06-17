using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace barbershopApi.Migrations
{
    /// <inheritdoc />
    public partial class XS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarberId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Barbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BarberId",
                table: "Customers",
                column: "BarberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Barbers_BarberId",
                table: "Customers",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Barbers_BarberId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Barbers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_BarberId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BarberId",
                table: "Customers");
        }
    }
}
