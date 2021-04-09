using Microsoft.EntityFrameworkCore.Migrations;

namespace Intex.Data.Migrations
{
    public partial class DbDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Initials = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioSamples", x => x.BioSampleId);
                });

            migrationBuilder.CreateTable(
                name: "Burials",
                columns: table => new
                {
                    MainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurialIdOld = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Burials", x => x.MainId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BioSamples");

            migrationBuilder.DropTable(
                name: "Burials");
        }
    }
}
