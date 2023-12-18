using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampSleepway_TeamGaJoL.Migrations
{
    /// <inheritdoc />
    public partial class serpatabord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_CamperId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CamperId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CamperId",
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

            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CamperId = table.Column<int>(type: "int", nullable: false),
                    startDate = table.Column<int>(type: "int", nullable: false),
                    endDate = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campers_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Councelors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CouncelorId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Councelors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Councelors_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Councelors_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NextOfKins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NextOfKinId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NextOfKins_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NextOfKins_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campers_PersonId",
                table: "Campers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Councelors_PersonId",
                table: "Councelors",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKins_PersonId",
                table: "NextOfKins",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropTable(
                name: "Councelors");

            migrationBuilder.DropTable(
                name: "NextOfKins");

            migrationBuilder.AddColumn<int>(
                name: "CamperId",
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
    }
}
