using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TraxxPlayer.Data.Migrations
{
    public partial class AddSoundCloudUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    avatar_url = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    discogs_name = table.Column<string>(nullable: true),
                    first_name = table.Column<string>(nullable: true),
                    followers_count = table.Column<int>(nullable: false),
                    followings_count = table.Column<int>(nullable: false),
                    full_name = table.Column<string>(nullable: true),
                    kind = table.Column<string>(nullable: true),
                    last_modified = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    myspace_name = table.Column<string>(nullable: true),
                    online = table.Column<bool>(nullable: false),
                    permalink = table.Column<string>(nullable: true),
                    permalink_url = table.Column<string>(nullable: true),
                    plan = table.Column<string>(nullable: true),
                    playlist_count = table.Column<int>(nullable: false),
                    public_favorites_count = table.Column<int>(nullable: false),
                    track_count = table.Column<int>(nullable: false),
                    uri = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    website_title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
