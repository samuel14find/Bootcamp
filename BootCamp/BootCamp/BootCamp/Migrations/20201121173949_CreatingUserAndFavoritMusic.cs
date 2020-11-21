using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BootCamp.Migrations
{
    public partial class CreatingUserAndFavoritMusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Photo = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoritMusic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MusicId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoritMusic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavoritMusic_Music_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoritMusic_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoritMusic_MusicId",
                table: "UserFavoritMusic",
                column: "MusicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoritMusic_UserId",
                table: "UserFavoritMusic",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFavoritMusic");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
