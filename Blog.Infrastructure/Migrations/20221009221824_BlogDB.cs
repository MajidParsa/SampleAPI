using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Infrastructure.Migrations
{
    public partial class BlogDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Username" },
                values: new object[] { 1, "jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=", "Majid" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreateDate", "CreatorId", "Description", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 10, 0, 18, 24, 530, DateTimeKind.Local).AddTicks(9155), 1, "Description 1", "Blog 1", null },
                    { 2, new DateTime(2022, 10, 10, 0, 18, 24, 530, DateTimeKind.Local).AddTicks(9200), 1, "Description 2", "Blog 2", null },
                    { 3, new DateTime(2022, 10, 10, 0, 18, 24, 530, DateTimeKind.Local).AddTicks(9203), 1, "Description 3", "Blog 3", null },
                    { 4, new DateTime(2022, 10, 10, 0, 18, 24, 530, DateTimeKind.Local).AddTicks(9204), 1, "Description 4", "Blog 4", null }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "BlogId", "Content", "CreateDate", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 1, "Post 1", new DateTime(2022, 10, 10, 0, 18, 24, 530, DateTimeKind.Local).AddTicks(9215), null },
                    { 2, 1, "Post 2", new DateTime(2022, 10, 10, 0, 18, 24, 530, DateTimeKind.Local).AddTicks(9221), null },
                    { 3, 2, "Post 3", new DateTime(2022, 10, 10, 0, 18, 24, 530, DateTimeKind.Local).AddTicks(9223), null },
                    { 4, 1, "Post 4", new DateTime(2022, 10, 10, 0, 18, 24, 530, DateTimeKind.Local).AddTicks(9225), null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreateDate", "CreatorId", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Comment 1", new DateTime(2022, 10, 10, 0, 18, 24, 530, DateTimeKind.Local).AddTicks(9236), 1, 1, null },
                    { 2, "Comment 2", new DateTime(2022, 10, 10, 0, 18, 24, 530, DateTimeKind.Local).AddTicks(9241), 1, 1, null },
                    { 3, "Comment 3", new DateTime(2022, 10, 10, 0, 18, 24, 530, DateTimeKind.Local).AddTicks(9243), 1, 1, null },
                    { 4, "Comment 4", new DateTime(2022, 10, 10, 0, 18, 24, 530, DateTimeKind.Local).AddTicks(9244), 1, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CreatorId",
                table: "Blogs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
