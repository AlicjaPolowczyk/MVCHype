using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HYPEDanceStudio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCreatedById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CreatedById",
                table: "Persons",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_AspNetUsers_CreatedById",
                table: "Persons",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_AspNetUsers_CreatedById",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CreatedById",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Persons");

     
        }
    }
}
