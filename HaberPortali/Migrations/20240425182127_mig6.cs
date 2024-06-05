using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaberPortali.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Files",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                table: "Files",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AspNetUsers_UserId",
                table: "Files",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_AspNetUsers_UserId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserId",
                table: "Files");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
