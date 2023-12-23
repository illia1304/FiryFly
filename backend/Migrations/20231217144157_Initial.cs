using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    surname = table.Column<string>(type: "text", nullable: true),
                    nickname = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    followerscount = table.Column<int>(name: "followers_count", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userid);
                });

            migrationBuilder.CreateTable(
                name: "Longreads",
                columns: table => new
                {
                    longreadid = table.Column<int>(name: "longread_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    contenttext = table.Column<string>(name: "content_text", type: "text", nullable: true),
                    autorid = table.Column<int>(name: "autor_id", type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    edit = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    likes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Longreads", x => x.longreadid);
                    table.ForeignKey(
                        name: "FK_Longreads_Users_autor_id",
                        column: x => x.autorid,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commments",
                columns: table => new
                {
                    commentid = table.Column<int>(name: "comment_id", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    commenttext = table.Column<string>(name: "comment_text", type: "text", nullable: true),
                    autorid = table.Column<int>(name: "autor_id", type: "integer", nullable: false),
                    longreadidcoment = table.Column<int>(name: "longread_idcoment", type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commments", x => x.commentid);
                    table.ForeignKey(
                        name: "FK_Commments_Longreads_longread_idcoment",
                        column: x => x.longreadidcoment,
                        principalTable: "Longreads",
                        principalColumn: "longread_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commments_Users_autor_id",
                        column: x => x.autorid,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commments_autor_id",
                table: "Commments",
                column: "autor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Commments_longread_idcoment",
                table: "Commments",
                column: "longread_idcoment");

            migrationBuilder.CreateIndex(
                name: "IX_Longreads_autor_id",
                table: "Longreads",
                column: "autor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commments");

            migrationBuilder.DropTable(
                name: "Longreads");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
