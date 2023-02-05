using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TournamintBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TournamentId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerOneFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerOneLastName = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerTwoFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerTwoLastName = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerOneResult = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerTwoResult = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    LocalUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchUser", x => new { x.Id, x.LocalUserId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "PlayerOneFirstName", "PlayerOneLastName", "PlayerOneResult", "PlayerTwoFirstName", "PlayerTwoLastName", "PlayerTwoResult", "TournamentId" },
                values: new object[,]
                {
                    { 1, "Test", "Testovich", "Win", "John", "Smith", "Loss", 1 },
                    { 2, "Test", "Testovich", "Loss", "John", "Smith", "Win", 1 },
                    { 3, "Test", "Testovich", "Win", "John", "Smith", "Loss", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "MatchUser");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
