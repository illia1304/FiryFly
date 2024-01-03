using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class addAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "autor_id",
                table: "Longreads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Longreads_autor_id",
                table: "Longreads",
                column: "autor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Longreads_Users_autor_id",
                table: "Longreads",
                column: "autor_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Longreads_Users_autor_id",
                table: "Longreads");

            migrationBuilder.DropIndex(
                name: "IX_Longreads_autor_id",
                table: "Longreads");

            migrationBuilder.DropColumn(
                name: "autor_id",
                table: "Longreads");
        }
    }
}
