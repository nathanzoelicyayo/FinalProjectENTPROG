using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectENTPROG.Migrations
{
    public partial class AddRelationshipUserIdScheduledUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Schedules",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ApplicationUserId",
                table: "Schedules",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_AspNetUsers_ApplicationUserId",
                table: "Schedules",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_AspNetUsers_ApplicationUserId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_ApplicationUserId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Schedules");
        }
    }
}
