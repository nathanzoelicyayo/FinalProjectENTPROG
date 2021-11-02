using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectENTPROG.Migrations
{
    public partial class ScheduleCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Slots",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slots",
                table: "Schedules");
        }
    }
}
