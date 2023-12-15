using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepway_TeamGaJoL.Migrations
{
    /// <inheritdoc />
    public partial class classes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CabinId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CamperId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CamperId1",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Camper_CabinId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CouncelorId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Person",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NextOfKinId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "endDate",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "startDate",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

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
                name: "IX_Person_CabinId",
                table: "Person",
                column: "CabinId",
                unique: true,
                filter: "[CabinId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Camper_CabinId",
                table: "Person",
                column: "Camper_CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CamperId",
                table: "Person",
                column: "CamperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Cabins_CabinId",
                table: "Person",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "CabinId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Cabins_Camper_CabinId",
                table: "Person",
                column: "Camper_CabinId",
                principalTable: "Cabins",
                principalColumn: "CabinId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_CamperId",
                table: "Person",
                column: "CamperId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Cabins_CabinId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Cabins_Camper_CabinId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_CamperId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "Cabins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CabinId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_Camper_CabinId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_CamperId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CabinId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CamperId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CamperId1",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Camper_CabinId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CouncelorId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "NextOfKinId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "endDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "startDate",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");
        }
    }
}
