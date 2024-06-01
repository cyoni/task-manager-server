using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Tasks_UserTaskId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_UserTaskId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UserTaskId",
                table: "Tags");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagUserTask");

            migrationBuilder.AddColumn<int>(
                name: "UserTaskId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UserTaskId",
                table: "Tags",
                column: "UserTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Tasks_UserTaskId",
                table: "Tags",
                column: "UserTaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
