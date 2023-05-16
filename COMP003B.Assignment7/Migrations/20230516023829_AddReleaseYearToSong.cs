using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP003B.Assignment7.Migrations
{
    /// <inheritdoc />
    public partial class AddReleaseYearToSong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SongId1",
                table: "Songs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_SongId1",
                table: "Songs",
                column: "SongId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Songs_SongId1",
                table: "Songs",
                column: "SongId1",
                principalTable: "Songs",
                principalColumn: "SongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Songs_SongId1",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_SongId1",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "SongId1",
                table: "Songs");
        }
    }
}
