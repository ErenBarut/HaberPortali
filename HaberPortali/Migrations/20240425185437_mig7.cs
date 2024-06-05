using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaberPortali.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Files",
                newName: "File_Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "File_Name",
                table: "Files",
                newName: "FileName");
        }
    }
}
