using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialTables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagUserTask");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TagId",
                table: "Tasks",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tags_TagId",
                table: "Tasks",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tags_TagId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TagId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Tasks");

            migrationBuilder.CreateTable(
                name: "TagUserTask",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    TasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagUserTask", x => new { x.TagsId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_TagUserTask_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagUserTask_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagUserTask_TasksId",
                table: "TagUserTask",
                column: "TasksId");
        }
    }
}
