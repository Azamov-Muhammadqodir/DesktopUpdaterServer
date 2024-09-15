using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvaloniaAppUpdaterServer.Migrations
{
    /// <inheritdoc />
    public partial class FileVersionAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "AppFiles",
                newName: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Version",
                table: "AppFiles",
                newName: "FileName");
        }
    }
}
