using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepway_TeamGaJoL.Migrations
{
    /// <inheritdoc />
    public partial class camperidinnextofkin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabins_Councelors_CouncelorId",
                table: "Cabins");

            migrationBuilder.AlterColumn<int>(
                name: "CouncelorId",
                table: "Cabins",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabins_Councelors_CouncelorId",
                table: "Cabins",
                column: "CouncelorId",
                principalTable: "Councelors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabins_Councelors_CouncelorId",
                table: "Cabins");

            migrationBuilder.AlterColumn<int>(
                name: "CouncelorId",
                table: "Cabins",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cabins_Councelors_CouncelorId",
                table: "Cabins",
                column: "CouncelorId",
                principalTable: "Councelors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
