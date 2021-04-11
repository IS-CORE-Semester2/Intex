using Microsoft.EntityFrameworkCore.Migrations;

namespace Intex.Data.Migrations
{
    public partial class FixC14Part4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "C14Data",
                columns: table => new
                {
                    BurialNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rack = table.Column<int>(nullable: true),
                    NorthSouthNumber = table.Column<int>(nullable: true),
                    NorthSouthLetter = table.Column<string>(nullable: true),
                    EastWestNumber = table.Column<int>(nullable: true),
                    EastWestLetter = table.Column<string>(nullable: true),
                    Square = table.Column<string>(nullable: true),
                    Area = table.Column<int>(nullable: true),
                    TubeNumber = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SizeMl = table.Column<int>(nullable: true),
                    Foci = table.Column<int>(nullable: true),
                    C14Sample2017 = table.Column<int>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    QuestionS = table.Column<string>(nullable: true),
                    OtherNumber = table.Column<int>(nullable: true),
                    Conventional14cAgeBp = table.Column<int>(nullable: true),
                    _14cCalendarDate = table.Column<int>(nullable: true),
                    Calibrated95CalendarDateMax = table.Column<int>(nullable: true),
                    Calibrated95CalendarDateMin = table.Column<int>(nullable: true),
                    Calibrated95CalendarDateSpan = table.Column<int>(nullable: true),
                    Calibrated95CalendarDateAvg = table.Column<int>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C14Data", x => x.BurialNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "C14Data");
        }
    }
}
