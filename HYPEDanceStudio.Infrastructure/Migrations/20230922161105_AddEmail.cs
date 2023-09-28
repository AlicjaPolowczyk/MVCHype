using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HYPEDanceStudio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignemnts_AspNetUsers_TaskById",
                table: "Assignemnts");

            migrationBuilder.DropIndex(
                name: "IX_Assignemnts_TaskById",
                table: "Assignemnts");

            migrationBuilder.DropColumn(
                name: "TaskById",
                table: "Assignemnts");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Assignemnts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Assignemnts");

            migrationBuilder.AddColumn<string>(
                name: "TaskById",
                table: "Assignemnts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Assignemnts_TaskById",
                table: "Assignemnts",
                column: "TaskById");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignemnts_AspNetUsers_TaskById",
                table: "Assignemnts",
                column: "TaskById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
