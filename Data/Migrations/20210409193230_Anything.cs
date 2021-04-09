using Microsoft.EntityFrameworkCore.Migrations;

namespace Intex.Data.Migrations
{
    public partial class Anything : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cranial2002s",
                columns: table => new
                {
                    SampleNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaximumCranialLength = table.Column<double>(nullable: true),
                    MaximumCranialBreadth = table.Column<double>(nullable: true),
                    BasionBreg = table.Column<double>(nullable: true),
                    BasionNasion = table.Column<double>(nullable: true),
                    BasionProsthionLength = table.Column<double>(nullable: true),
                    BizygomaticDiameter = table.Column<double>(nullable: true),
                    NasionProsthion = table.Column<double>(nullable: true),
                    MaximumNasalBreadth = table.Column<double>(nullable: true),
                    InterorbitalBreadth = table.Column<double>(nullable: true),
                    BurialPositioningNorthSouthNumber = table.Column<string>(nullable: true),
                    BurialPositioningNorthSouthDirection = table.Column<string>(nullable: true),
                    BurialPositioningEastWestNumber = table.Column<string>(nullable: true),
                    BurialPositioningEastWestDirection = table.Column<string>(nullable: true),
                    BurialNumber = table.Column<int>(nullable: true),
                    BurialDepth = table.Column<double>(nullable: true),
                    BurialSubPlotDirection = table.Column<string>(nullable: true),
                    BurialArtifactDescription = table.Column<string>(nullable: true),
                    BuriedWithArtifacts = table.Column<bool>(nullable: true),
                    GilesGender = table.Column<string>(nullable: true),
                    BodyGender = table.Column<string>(nullable: true),
                    BurialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cranial2002s", x => x.SampleNumber);
                    table.ForeignKey(
                        name: "FK_Cranial2002s_Burials_BurialId",
                        column: x => x.BurialId,
                        principalTable: "Burials",
                        principalColumn: "BurialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OracleSpreads",
                columns: table => new
                {
                    Gamous = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialSquare = table.Column<int>(nullable: true),
                    Nors = table.Column<string>(nullable: true),
                    Sq2 = table.Column<int>(nullable: true),
                    Eorw = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Burialnum = table.Column<int>(nullable: true),
                    Westtohead = table.Column<double>(nullable: true),
                    Westtofeet = table.Column<double>(nullable: true),
                    Southtohead = table.Column<double>(nullable: true),
                    Southtofeet = table.Column<double>(nullable: true),
                    Depth = table.Column<double>(nullable: true),
                    Preservation = table.Column<string>(nullable: true),
                    Burialicon = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    Sexmethod = table.Column<string>(nullable: true),
                    Ageatdeath = table.Column<string>(nullable: true),
                    Agemethod = table.Column<string>(nullable: true),
                    Haircolor = table.Column<string>(nullable: true),
                    Sample = table.Column<bool>(nullable: true),
                    BurialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OracleSpreads", x => x.Gamous);
                    table.ForeignKey(
                        name: "FK_OracleSpreads_Burials_BurialId",
                        column: x => x.BurialId,
                        principalTable: "Burials",
                        principalColumn: "BurialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cranial2002s_BurialId",
                table: "Cranial2002s",
                column: "BurialId");

            migrationBuilder.CreateIndex(
                name: "IX_OracleSpreads_BurialId",
                table: "OracleSpreads",
                column: "BurialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cranial2002s");

            migrationBuilder.DropTable(
                name: "OracleSpreads");
        }
    }
}
