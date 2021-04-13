using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intex.Data.Migrations
{
    public partial class Exhumation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exhumations",
                columns: table => new
                {
                    BurialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LowPairNS = table.Column<int>(nullable: false),
                    HighPairNS = table.Column<int>(nullable: false),
                    BurialLocationNS = table.Column<string>(nullable: false),
                    LowPairEW = table.Column<int>(nullable: false),
                    HighPairEW = table.Column<int>(nullable: false),
                    BurialLocationEW = table.Column<string>(nullable: false),
                    Area = table.Column<string>(nullable: false),
                    ShaftNumber = table.Column<string>(nullable: true),
                    BurialNumber = table.Column<int>(nullable: false),
                    SouthToHeadInMeters = table.Column<int>(nullable: false),
                    SouthToFeetInMeters = table.Column<int>(nullable: false),
                    WestToHeadInMeters = table.Column<int>(nullable: false),
                    WestToFeetInMeters = table.Column<int>(nullable: false),
                    LengthInMeters = table.Column<int>(nullable: false),
                    DepthInMeters = table.Column<int>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true),
                    BurialGoods = table.Column<bool>(nullable: true),
                    Hair = table.Column<bool>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    BurialMaterials = table.Column<bool>(nullable: true),
                    ExcavationRecorder = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Time = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhumations", x => x.BurialID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exhumations");
        }
    }
}
