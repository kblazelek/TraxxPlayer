using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TraxxPlayer.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    isDefault = table.Column<bool>(nullable: false),
                    username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    TrackID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    MessageType = table.Column<int>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.id);
                    table.ForeignKey(
                        name: "FK_Playlists_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TracksHistory",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    TrackID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TracksHistory", x => x.id);
                    table.ForeignKey(
                        name: "FK_TracksHistory_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistTracks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlaylistID = table.Column<int>(nullable: false),
                    TrackID = table.Column<int>(nullable: false),
                    TrackOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistTracks", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlaylistTracks_Playlists_PlaylistID",
                        column: x => x.PlaylistID,
                        principalTable: "Playlists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserID",
                table: "Likes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserID",
                table: "Logs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UserID",
                table: "Playlists",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistTracks_PlaylistID",
                table: "PlaylistTracks",
                column: "PlaylistID");

            migrationBuilder.CreateIndex(
                name: "IX_TracksHistory_UserID",
                table: "TracksHistory",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "PlaylistTracks");

            migrationBuilder.DropTable(
                name: "TracksHistory");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
