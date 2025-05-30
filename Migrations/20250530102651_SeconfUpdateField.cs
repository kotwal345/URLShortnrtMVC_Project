using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShortnerMVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class SeconfUpdateField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShortUrls_Users_UserModelId",
                table: "ShortUrls");

            migrationBuilder.RenameColumn(
                name: "UserModelId",
                table: "ShortUrls",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShortUrls_UserModelId",
                table: "ShortUrls",
                newName: "IX_ShortUrls_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShortUrls_Users_UserId",
                table: "ShortUrls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShortUrls_Users_UserId",
                table: "ShortUrls");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShortUrls",
                newName: "UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ShortUrls_UserId",
                table: "ShortUrls",
                newName: "IX_ShortUrls_UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShortUrls_Users_UserModelId",
                table: "ShortUrls",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
