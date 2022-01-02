using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroVideosCatalog.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "videos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    YearLaunched = table.Column<int>(type: "INTEGER", maxLength: 4, nullable: false),
                    Opened = table.Column<bool>(type: "INTEGER", maxLength: 1, nullable: false),
                    Rating = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Duration = table.Column<float>(type: "REAL", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "castMembers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    CastMemberType = table.Column<int>(type: "VARCHAR", maxLength: 10, nullable: false),
                    VideoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_castMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_castMembers_videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "dbo",
                        principalTable: "videos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "genres",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    VideoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_genres_videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "dbo",
                        principalTable: "videos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "videoFiles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Duration = table.Column<float>(type: "REAL", maxLength: 10, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    VideoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videoFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_videoFiles_videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "dbo",
                        principalTable: "videos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    GenreId = table.Column<Guid>(type: "TEXT", nullable: true),
                    VideoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categories_genres_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "dbo",
                        principalTable: "genres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_categories_videos_VideoId",
                        column: x => x.VideoId,
                        principalSchema: "dbo",
                        principalTable: "videos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_castMembers_VideoId",
                schema: "dbo",
                table: "castMembers",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_GenreId",
                schema: "dbo",
                table: "categories",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_VideoId",
                schema: "dbo",
                table: "categories",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_genres_VideoId",
                schema: "dbo",
                table: "genres",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_videoFiles_VideoId",
                schema: "dbo",
                table: "videoFiles",
                column: "VideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "castMembers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "videoFiles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "genres",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "videos",
                schema: "dbo");
        }
    }
}
