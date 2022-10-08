using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Infrastructure.Migrations
{
    public partial class BloDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreateDate", "CreatorId", "PostId" },
                values: new object[,]
                {
                    { 1, "Comment 1", new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(581), 1, 1 },
                    { 2, "Comment 2", new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(587), 1, 1 },
                    { 3, "Comment 3", new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(590), 1, 1 },
                    { 4, "Comment 4", new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(593), 1, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(541));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(545));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 10, 8, 21, 27, 18, 624, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CommentId",
                table: "Posts",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatorId",
                table: "Comments",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Comments_CommentId",
                table: "Posts",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Comments_CommentId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CommentId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 10, 8, 21, 9, 56, 155, DateTimeKind.Local).AddTicks(1244));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 10, 8, 21, 9, 56, 155, DateTimeKind.Local).AddTicks(1283));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 10, 8, 21, 9, 56, 155, DateTimeKind.Local).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 10, 8, 21, 9, 56, 155, DateTimeKind.Local).AddTicks(1286));
        }
    }
}
