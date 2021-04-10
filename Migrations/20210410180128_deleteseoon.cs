using Microsoft.EntityFrameworkCore.Migrations;

namespace Intex.Migrations
{
    public partial class deleteseoon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Calibrated95CalendarDateAVG = table.Column<string>(name: "Calibrated 95% Calendar Date AVG", fixedLength: true, maxLength: 100, nullable: true),
                    Category = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true),
                    Notes = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C14 Data", x => x.BurialNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "C14 Data");
        }
    }
}
