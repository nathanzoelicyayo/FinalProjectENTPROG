using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectENTPROG.Migrations
{
    public partial class UpdatedScheduleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_AspNetUsers_ApplicationUserId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ScheduledUser",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Schedules",
                newName: "ScheduledUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_ApplicationUserId",
                table: "Schedules",
                newName: "IX_Schedules_ScheduledUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_AspNetUsers_ScheduledUserId",
                table: "Schedules",
                column: "ScheduledUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_AspNetUsers_ScheduledUserId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "ScheduledUserId",
                table: "Schedules",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_ScheduledUserId",
                table: "Schedules",
                newName: "IX_Schedules_ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "ScheduledUser",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_AspNetUsers_ApplicationUserId",
                table: "Schedules",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
