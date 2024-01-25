using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameCollectionAPI_DAL.Migrations
{
    public partial class AlterModelsRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Games_GameId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_GameImages_Games_GameId",
                table: "GameImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_DevelopmentCompanies_GameDevelopmentCompanyDevelopmentCompanyId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_UserId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_GameImages_GameId",
                table: "GameImages");

            migrationBuilder.DropIndex(
                name: "IX_Categories_GameId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameImages");

            migrationBuilder.DropColumn(
                name: "GameImageExtension",
                table: "GameImages");

            migrationBuilder.DropColumn(
                name: "GameImageName",
                table: "GameImages");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "GameSynopsis",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GameImage",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "GameDevelopmentCompanyDevelopmentCompanyId",
                table: "Games",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ImageGameGameId",
                table: "GameImages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "CategoryGame",
                columns: table => new
                {
                    GameCategoryCategoryId = table.Column<int>(type: "int", nullable: false),
                    GamesGameId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGame", x => new { x.GameCategoryCategoryId, x.GamesGameId });
                    table.ForeignKey(
                        name: "FK_CategoryGame_Categories_GameCategoryCategoryId",
                        column: x => x.GameCategoryCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryGame_Games_GamesGameId",
                        column: x => x.GamesGameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameUser",
                columns: table => new
                {
                    GameUsersUserId = table.Column<long>(type: "bigint", nullable: false),
                    UserGamesGameId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUser", x => new { x.GameUsersUserId, x.UserGamesGameId });
                    table.ForeignKey(
                        name: "FK_GameUser_Games_UserGamesGameId",
                        column: x => x.UserGamesGameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUser_Users_GameUsersUserId",
                        column: x => x.GameUsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameImages_ImageGameGameId",
                table: "GameImages",
                column: "ImageGameGameId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGame_GamesGameId",
                table: "CategoryGame",
                column: "GamesGameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUser_UserGamesGameId",
                table: "GameUser",
                column: "UserGamesGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameImages_Games_ImageGameGameId",
                table: "GameImages",
                column: "ImageGameGameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_DevelopmentCompanies_GameDevelopmentCompanyDevelopmentCompanyId",
                table: "Games",
                column: "GameDevelopmentCompanyDevelopmentCompanyId",
                principalTable: "DevelopmentCompanies",
                principalColumn: "DevelopmentCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameImages_Games_ImageGameGameId",
                table: "GameImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_DevelopmentCompanies_GameDevelopmentCompanyDevelopmentCompanyId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "CategoryGame");

            migrationBuilder.DropTable(
                name: "GameUser");

            migrationBuilder.DropIndex(
                name: "IX_GameImages_ImageGameGameId",
                table: "GameImages");

            migrationBuilder.DropColumn(
                name: "ImageGameGameId",
                table: "GameImages");

            migrationBuilder.AlterColumn<string>(
                name: "GameSynopsis",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GameImage",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "GameDevelopmentCompanyDevelopmentCompanyId",
                table: "Games",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Games",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GameId",
                table: "GameImages",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameImageExtension",
                table: "GameImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GameImageName",
                table: "GameImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "GameId",
                table: "Categories",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserId",
                table: "Games",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameImages_GameId",
                table: "GameImages",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GameId",
                table: "Categories",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Games_GameId",
                table: "Categories",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameImages_Games_GameId",
                table: "GameImages",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_DevelopmentCompanies_GameDevelopmentCompanyDevelopmentCompanyId",
                table: "Games",
                column: "GameDevelopmentCompanyDevelopmentCompanyId",
                principalTable: "DevelopmentCompanies",
                principalColumn: "DevelopmentCompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
