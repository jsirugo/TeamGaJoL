using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepway_TeamGaJoL.Migrations
{
    /// <inheritdoc />
    public partial class test5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CamperId1",
                table: "Persons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CamperId1",
                table: "Persons",
                type: "int",
                nullable: true);
        }
    }
}
