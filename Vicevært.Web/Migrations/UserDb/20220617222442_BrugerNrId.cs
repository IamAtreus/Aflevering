using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicevært.Web.Migrations.UserDb
{
    public partial class BrugerNrId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrugerIdNr",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrugerIdNr",
                table: "AspNetUsers");
        }
    }
}
