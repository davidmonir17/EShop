using Microsoft.EntityFrameworkCore.Migrations;

namespace order.infrastructure.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders1",
                table: "Orders1");

            migrationBuilder.RenameTable(
                name: "Orders1",
                newName: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Orders1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders1",
                table: "Orders1",
                column: "Id");
        }
    }
}
