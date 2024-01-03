using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class addAuthortoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Longreads_Users_autor_id",
                table: "Longreads");

            migrationBuilder.RenameColumn(
                name: "autor_id",
                table: "Longreads",
                newName: "author_id");

            migrationBuilder.RenameIndex(
                name: "IX_Longreads_autor_id",
                table: "Longreads",
                newName: "IX_Longreads_author_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Longreads_Users_author_id",
                table: "Longreads",
                column: "author_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Longreads_Users_author_id",
                table: "Longreads");

            migrationBuilder.RenameColumn(
                name: "author_id",
                table: "Longreads",
                newName: "autor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Longreads_author_id",
                table: "Longreads",
                newName: "IX_Longreads_autor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Longreads_Users_autor_id",
                table: "Longreads",
                column: "autor_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
