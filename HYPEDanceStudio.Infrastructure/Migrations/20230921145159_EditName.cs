using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HYPEDanceStudio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_TaskById",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Assignemnts");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TaskById",
                table: "Assignemnts",
                newName: "IX_Assignemnts_TaskById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignemnts",
                table: "Assignemnts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignemnts_AspNetUsers_TaskById",
                table: "Assignemnts",
                column: "TaskById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignemnts_AspNetUsers_TaskById",
                table: "Assignemnts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignemnts",
                table: "Assignemnts");

            migrationBuilder.RenameTable(
                name: "Assignemnts",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_Assignemnts_TaskById",
                table: "Tasks",
                newName: "IX_Tasks_TaskById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_AspNetUsers_TaskById",
                table: "Tasks",
                column: "TaskById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
