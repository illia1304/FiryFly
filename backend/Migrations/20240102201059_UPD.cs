using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UPD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commments_Longreads_longread_idcoment",
                table: "Commments");

            migrationBuilder.DropForeignKey(
                name: "FK_Commments_Users_autor_id",
                table: "Commments");

            migrationBuilder.DropForeignKey(
                name: "FK_Longreads_Users_autor_id",
                table: "Longreads");

            migrationBuilder.DropColumn(
                name: "passwordHash",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "autor_id",
                table: "Longreads",
                newName: "Autor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Longreads_autor_id",
                table: "Longreads",
                newName: "IX_Longreads_Autor_id");

            migrationBuilder.RenameColumn(
                name: "longread_idcoment",
                table: "Commments",
                newName: "Longread_idcoment");

            migrationBuilder.RenameColumn(
                name: "autor_id",
                table: "Commments",
                newName: "Autor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Commments_longread_idcoment",
                table: "Commments",
                newName: "IX_Commments_Longread_idcoment");

            migrationBuilder.RenameIndex(
                name: "IX_Commments_autor_id",
                table: "Commments",
                newName: "IX_Commments_Autor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commments_Longreads_Longread_idcoment",
                table: "Commments",
                column: "Longread_idcoment",
                principalTable: "Longreads",
                principalColumn: "longread_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commments_Users_Autor_id",
                table: "Commments",
                column: "Autor_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Longreads_Users_Autor_id",
                table: "Longreads",
                column: "Autor_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commments_Longreads_Longread_idcoment",
                table: "Commments");

            migrationBuilder.DropForeignKey(
                name: "FK_Commments_Users_Autor_id",
                table: "Commments");

            migrationBuilder.DropForeignKey(
                name: "FK_Longreads_Users_Autor_id",
                table: "Longreads");

            migrationBuilder.RenameColumn(
                name: "Autor_id",
                table: "Longreads",
                newName: "autor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Longreads_Autor_id",
                table: "Longreads",
                newName: "IX_Longreads_autor_id");

            migrationBuilder.RenameColumn(
                name: "Longread_idcoment",
                table: "Commments",
                newName: "longread_idcoment");

            migrationBuilder.RenameColumn(
                name: "Autor_id",
                table: "Commments",
                newName: "autor_id");

            migrationBuilder.RenameIndex(
                name: "IX_Commments_Longread_idcoment",
                table: "Commments",
                newName: "IX_Commments_longread_idcoment");

            migrationBuilder.RenameIndex(
                name: "IX_Commments_Autor_id",
                table: "Commments",
                newName: "IX_Commments_autor_id");

            migrationBuilder.AddColumn<string>(
                name: "passwordHash",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Commments_Longreads_longread_idcoment",
                table: "Commments",
                column: "longread_idcoment",
                principalTable: "Longreads",
                principalColumn: "longread_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commments_Users_autor_id",
                table: "Commments",
                column: "autor_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

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
