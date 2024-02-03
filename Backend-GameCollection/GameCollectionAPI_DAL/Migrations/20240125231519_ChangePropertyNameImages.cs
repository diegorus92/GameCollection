using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameCollectionAPI_DAL.Migrations
{
    public partial class ChangePropertyNameImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameImagePath",
                table: "GameImages",
                newName: "GameImageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameImageName",
                table: "GameImages",
                newName: "GameImagePath");
        }
    }
}
