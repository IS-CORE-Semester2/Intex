using Microsoft.EntityFrameworkCore.Migrations;

namespace Intex.Data.Migrations
{
    public partial class Anything : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burials",
                columns: table => new
                {
                    BurialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialLocation = table.Column<string>(nullable: true),
                    BurialLocationNs = table.Column<string>(nullable: true),
                    BurialLocationEw = table.Column<string>(nullable: true),
                    LowPairNs = table.Column<int>(nullable: true),
                    HighPairNs = table.Column<int>(nullable: true),
                    LowPairEw = table.Column<int>(nullable: true),
                    HighPairEw = table.Column<int>(nullable: true),
                    BurialSubplot = table.Column<string>(nullable: true),
                    BurialDepth = table.Column<decimal>(nullable: true),
                    SouthToHead = table.Column<decimal>(nullable: true),
                    SouthToFeet = table.Column<decimal>(nullable: true),
                    EastToHead = table.Column<decimal>(nullable: true),
                    EastToFeet = table.Column<decimal>(nullable: true),
                    BurialSituation = table.Column<string>(nullable: true),
                    LengthOfRemains = table.Column<decimal>(nullable: true),
                    BurialNumber = table.Column<int>(nullable: true),
                    SampleNumber = table.Column<int>(nullable: true),
                    GenderGe = table.Column<string>(nullable: true),
                    GeFunctionTotal = table.Column<decimal>(nullable: true),
                    GenderBodyCol = table.Column<string>(nullable: true),
                    BasilarSuture = table.Column<string>(nullable: true),
                    VentralArc = table.Column<int>(nullable: true),
                    SubpubicAngle = table.Column<int>(nullable: true),
                    SciaticNotch = table.Column<int>(nullable: true),
                    PubicBone = table.Column<int>(nullable: true),
                    PreaurSulcus = table.Column<int>(nullable: true),
                    MedialIpRamus = table.Column<int>(nullable: true),
                    DorsalPitting = table.Column<int>(nullable: true),
                    ForemanMagnum = table.Column<decimal>(nullable: true),
                    FemurHead = table.Column<decimal>(nullable: true),
                    HumerusHead = table.Column<decimal>(nullable: true),
                    Osteophytosis = table.Column<string>(nullable: true),
                    PubicSymphysis = table.Column<string>(nullable: true),
                    BoneLength = table.Column<decimal>(nullable: true),
                    FemurLength = table.Column<decimal>(nullable: true),
                    HumerusLength = table.Column<decimal>(nullable: true),
                    TibiaLength = table.Column<decimal>(nullable: true),
                    Robust = table.Column<int>(nullable: true),
                    SupraorbitalRidges = table.Column<int>(nullable: true),
                    OrbitEdge = table.Column<int>(nullable: true),
                    ParietalBossing = table.Column<int>(nullable: true),
                    Gonian = table.Column<int>(nullable: true),
                    NuchalCrest = table.Column<int>(nullable: true),
                    ZygomaticCrest = table.Column<int>(nullable: true),
                    CranialSuture = table.Column<string>(nullable: true),
                    MaximumCranialLength = table.Column<decimal>(nullable: true),
                    MaximumCranialBreadth = table.Column<decimal>(nullable: true),
                    BasionBregmaHeight = table.Column<decimal>(nullable: true),
                    BasionNasion = table.Column<decimal>(nullable: true),
                    BasionProsthionLength = table.Column<decimal>(nullable: true),
                    BizygomaticDiameter = table.Column<decimal>(nullable: true),
                    NasionProsthion = table.Column<decimal>(nullable: true),
                    MaximumNasalBreadth = table.Column<decimal>(nullable: true),
                    InterorbitalBreadth = table.Column<decimal>(nullable: true),
                    ArtifactsDescription = table.Column<string>(nullable: true),
                    HairColor = table.Column<string>(nullable: true),
                    PreservationIndex = table.Column<string>(nullable: true),
                    HairTaken = table.Column<bool>(nullable: false),
                    SoftTissueTaken = table.Column<bool>(nullable: false),
                    BoneTaken = table.Column<bool>(nullable: false),
                    ToothTaken = table.Column<bool>(nullable: false),
                    TextileTaken = table.Column<bool>(nullable: false),
                    DescriptionOfTaken = table.Column<string>(nullable: true),
                    ArtifactFound = table.Column<bool>(nullable: false),
                    EstimateAge = table.Column<decimal>(nullable: true),
                    EstimateLivingStature = table.Column<decimal>(nullable: true),
                    ToothAttrition = table.Column<string>(nullable: true),
                    ToothEruption = table.Column<string>(nullable: true),
                    PathologyAnomalies = table.Column<string>(nullable: true),
                    EpiphysealUnion = table.Column<string>(nullable: true),
                    YearFound = table.Column<string>(nullable: true),
                    MonthFound = table.Column<string>(nullable: true),
                    DayFound = table.Column<string>(nullable: true),
                    HeadDirection = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burials", x => x.BurialId);
                });


            migrationBuilder.CreateTable(
                name: "BioSamples",
                columns: table => new
                {
                    BioSampleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RackNumber = table.Column<double>(nullable: true),
                    BagNumber = table.Column<string>(nullable: true),
                    LowPairNs = table.Column<double>(nullable: true),
                    HighPairNs = table.Column<double>(nullable: true),
                    BurialLocationNs = table.Column<string>(nullable: true),
                    LowPairEw = table.Column<double>(nullable: true),
                    HighPairEw = table.Column<double>(nullable: true),
                    BurialLocationEw = table.Column<string>(nullable: true),
                    BurialSubplot = table.Column<string>(nullable: true),
                    BurialNumber = table.Column<double>(nullable: true),
                    Date = table.Column<double>(nullable: true),
                    PreviouslySampled = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    BurialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioSamples", x => x.BioSampleId);
                    table.ForeignKey(
                        name: "FK_BioSamples_Burials_BurialId",
                        column: x => x.BurialId,
                        principalTable: "Burials",
                        principalColumn: "BurialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BioSamples_BurialId",
                table: "BioSamples",
                column: "BurialId");
        



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

            migrationBuilder.CreateTable(
                name: "C14 Data",
                columns: table => new
                {
                    BurialNumber = table.Column<int>(name: "Burial Number", nullable: false),
                    Rack = table.Column<int>(nullable: true),
                    NorthSouthNumber = table.Column<int>(name: "North South Number", nullable: true),
                    NorthSouthLetter = table.Column<string>(name: "North South Letter", fixedLength: true, maxLength: 10, nullable: true),
                    EastWestNumber = table.Column<int>(name: "East West Number", nullable: true),
                    EastWestLetter = table.Column<string>(name: "East West Letter", fixedLength: true, maxLength: 10, nullable: true),
                    Square = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true),
                    Area = table.Column<int>(nullable: true),
                    TubeNumber = table.Column<int>(name: "Tube Number", nullable: true),
                    Description = table.Column<string>(fixedLength: true, maxLength: 1000, nullable: true),
                    Sizeml = table.Column<int>(name: "Size (ml)", nullable: true),
                    Foci = table.Column<int>(nullable: true),
                    C14Sample2017 = table.Column<int>(name: "C14 Sample 2017", nullable: true),
                    Location = table.Column<string>(fixedLength: true, maxLength: 1000, nullable: true),
                    Questions = table.Column<string>(name: "Question(s)", fixedLength: true, maxLength: 1000, nullable: true),
                    OtherNumber = table.Column<int>(name: "Other Number", nullable: true),
                    Conventional14CAgeBP = table.Column<int>(name: "Conventional 14C Age BP", nullable: true),
                    _14CCalendarDate = table.Column<int>(name: "14C Calendar Date", nullable: true),
                    Calibrated95CalendarDateMAX = table.Column<int>(name: "Calibrated 95% Calendar Date MAX", nullable: true),
                    Calibrated95CalendarDateMIN = table.Column<int>(name: "Calibrated 95% Calendar Date MIN", nullable: true),
                    Calibrated95CalendarDateSPAN = table.Column<int>(name: "Calibrated 95% Calendar Date SPAN", nullable: true),
                    Calibrated95CalendarDateAVG = table.Column<int>(name: "Calibrated 95% Calendar Date AVG", fixedLength: true, maxLength: 100, nullable: true),
                    Category = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true),
                    Notes = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C14 Data", x => x.BurialNumber);
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

        }
    }
}
