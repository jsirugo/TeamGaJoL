using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepway_TeamGaJoL.Migrations
{
    /// <inheritdoc />
    public partial class classesupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CamperId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CamperId1",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CouncelorId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Persons",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NextOfKinId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "endDate",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "startDate",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cabins",
                columns: table => new
                {
                    CabinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabins", x => x.CabinId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CamperId",
                table: "Persons",
                column: "CamperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_CamperId",
                table: "Persons",
                column: "CamperId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_CamperId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Cabins");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CamperId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CamperId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CamperId1",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CouncelorId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "NextOfKinId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "endDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "startDate",
                table: "Persons");
        }
    }
}
