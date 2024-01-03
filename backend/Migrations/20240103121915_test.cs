using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Longreads_Users_Autor_id",
                table: "Longreads");

            migrationBuilder.DropIndex(
                name: "IX_Longreads_Autor_id",
                table: "Longreads");

            migrationBuilder.DropColumn(
                name: "Autor_id",
                table: "Longreads");

            migrationBuilder.DropColumn(
                name: "created",
                table: "Longreads");

            migrationBuilder.DropColumn(
                name: "edit",
                table: "Longreads");

            migrationBuilder.DropColumn(
                name: "likes",
                table: "Longreads");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Autor_id",
                table: "Longreads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "created",
                table: "Longreads",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "edit",
                table: "Longreads",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "likes",
                table: "Longreads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Longreads_Autor_id",
                table: "Longreads",
                column: "Autor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Longreads_Users_Autor_id",
                table: "Longreads",
                column: "Autor_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
