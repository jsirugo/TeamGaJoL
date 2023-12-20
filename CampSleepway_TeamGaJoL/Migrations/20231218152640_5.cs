using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepway_TeamGaJoL.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CounselorId",
                table: "Cabins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CounselorId",
                table: "Cabins");
        }
    }
}
