using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaberPortali.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Categories_CategoriesCategoryId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoriesCategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "News",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "News",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Categories_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Categories_CategoryId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "News",
                newName: "User");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoriesCategoryId",
                table: "News",
                column: "CategoriesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Categories_CategoriesCategoryId",
                table: "News",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
