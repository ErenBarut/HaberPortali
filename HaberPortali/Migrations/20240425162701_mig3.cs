using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaberPortali.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUsersId",
                table: "Files",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_AppUsersId",
                table: "Files",
                column: "AppUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AspNetUsers_AppUsersId",
                table: "Files",
                column: "AppUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_AspNetUsers_AppUsersId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_AppUsersId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "AppUsersId",
                table: "Files");
        }
    }
}
