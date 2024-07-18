using Microsoft.EntityFrameworkCore.Migrations;

namespace Transit.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RouteStops",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Order = table.Column<short>(type: "INTEGER", nullable: false),
                    Number = table.Column<short>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteStops", x => x.Id);
                    table.UniqueConstraint("AK_RouteStops_Number", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "RouteSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StopNumber = table.Column<short>(type: "INTEGER", nullable: false),
                    Timepoint = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteSchedules_RouteStops_StopNumber",
                        column: x => x.StopNumber,
                        principalTable: "RouteStops",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 1L, "Beaudry Ave & 3rd St", (short)6041, (short)1 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 21L, "Vermont Ave & 36th Pl", (short)6120, (short)21 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 22L, "Jefferson Blvd & Vermont Ave", (short)6121, (short)22 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 23L, "Jefferson Blvd & McClintock Ave", (short)6122, (short)23 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 24L, "Jefferson Blvd & Hoover St", (short)6123, (short)24 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 25L, "Figueroa St & 33rd St", (short)6124, (short)25 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 26L, "Figueroa St & 30th St", (short)6125, (short)26 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 20L, "Vermont Ave & 37th Pl", (short)6119, (short)20 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 27L, "Figueroa St & Adams Blvd", (short)6126, (short)27 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 29L, "Figueroa St & Washington Blvd", (short)6128, (short)29 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 30L, "Figueroa St & Venice Blvd", (short)6129, (short)30 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 31L, "Figueroa St & 12th St", (short)6130, (short)31 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 32L, "Figueroa & 11th St (Crypto.com Arena)", (short)6132, (short)32 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 33L, "Figueroa St & Olympic Blvd", (short)6133, (short)33 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 34L, "Figueroa St & 8th St", (short)6135, (short)34 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 28L, "Figueroa St & 23rd St", (short)6127, (short)28 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 19L, "Vermont Ave & Exposition Blvd", (short)6040, (short)19 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 18L, "Exposition Blvd & Watt Way", (short)6152, (short)18 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 17L, "Exposition Blvd & Trousdale Pkwy", (short)6216, (short)17 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 2L, "4th St & Figueroa St", (short)6138, (short)2 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 3L, "Flower St & 5th St", (short)6021, (short)3 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 4L, "Flower St & 7th St", (short)6139, (short)4 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 5L, "Flower St & 8th St", (short)6140, (short)5 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 6L, "Flower St & 9th St", (short)9638, (short)6 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 7L, "Flower St & Olympic Blvd", (short)6142, (short)7 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 8L, "Figueroa & 12th St (Crypto.com Arena)", (short)6143, (short)8 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 9L, "Figueroa St & Pico Blvd", (short)6144, (short)9 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 10L, "Figueroa St & Venice Blvd", (short)6145, (short)10 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 11L, "Figueroa St & Washington Blvd", (short)6146, (short)11 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 12L, "Figueroa St & 23rd St", (short)6147, (short)12 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 13L, "Figueroa St & Adams Blvd", (short)6148, (short)13 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 14L, "Figueroa St & 30th St", (short)6149, (short)14 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 15L, "Figueroa St & Jefferson Blvd", (short)6150, (short)15 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 16L, "Figueroa St & McCarthy Way", (short)6151, (short)16 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 35L, "Figueroa St & 7th St", (short)6136, (short)35 });

            migrationBuilder.InsertData(
                table: "RouteStops",
                columns: new[] { "Id", "Name", "Number", "Order" },
                values: new object[] { 36L, "Figueroa St & 5th St", (short)6137, (short)36 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 1L, (short)6041, (short)600 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 24L, (short)6123, (short)950 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 59L, (short)6122, (short)1540 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 23L, (short)6122, (short)940 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 58L, (short)6121, (short)1530 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 22L, (short)6121, (short)930 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 57L, (short)6120, (short)1520 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 21L, (short)6120, (short)920 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 56L, (short)6119, (short)1510 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 60L, (short)6123, (short)1550 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 20L, (short)6119, (short)910 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 19L, (short)6040, (short)900 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 90L, (short)6152, (short)2050 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 54L, (short)6152, (short)1450 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 18L, (short)6152, (short)850 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 89L, (short)6216, (short)2040 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 53L, (short)6216, (short)1440 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 17L, (short)6216, (short)840 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 88L, (short)6151, (short)2030 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 55L, (short)6040, (short)1500 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 25L, (short)6124, (short)1000 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 61L, (short)6124, (short)1600 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 26L, (short)6125, (short)1010 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 71L, (short)6136, (short)1740 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 35L, (short)6136, (short)1140 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 70L, (short)6135, (short)1730 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 34L, (short)6135, (short)1130 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 69L, (short)6133, (short)1720 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 33L, (short)6133, (short)1120 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 68L, (short)6132, (short)1710 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 32L, (short)6132, (short)1110 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 67L, (short)6130, (short)1700 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 31L, (short)6130, (short)1100 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 66L, (short)6129, (short)1650 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 30L, (short)6129, (short)1050 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 65L, (short)6128, (short)1640 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 29L, (short)6128, (short)1040 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 64L, (short)6127, (short)1630 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 28L, (short)6127, (short)1030 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 63L, (short)6126, (short)1620 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 27L, (short)6126, (short)1020 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 62L, (short)6125, (short)1610 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 52L, (short)6151, (short)1430 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 16L, (short)6151, (short)830 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 87L, (short)6150, (short)2020 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 51L, (short)6150, (short)1420 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 43L, (short)6142, (short)1300 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 7L, (short)6142, (short)700 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 78L, (short)9638, (short)1850 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 42L, (short)9638, (short)1250 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 6L, (short)9638, (short)650 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 77L, (short)6140, (short)1840 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 41L, (short)6140, (short)1240 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 5L, (short)6140, (short)640 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 76L, (short)6139, (short)1830 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 40L, (short)6139, (short)1230 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 4L, (short)6139, (short)630 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 75L, (short)6021, (short)1820 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 39L, (short)6021, (short)1220 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 3L, (short)6021, (short)620 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 74L, (short)6138, (short)1810 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 38L, (short)6138, (short)1210 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 2L, (short)6138, (short)610 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 73L, (short)6041, (short)1800 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 37L, (short)6041, (short)1200 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 79L, (short)6142, (short)1900 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 36L, (short)6137, (short)1150 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 8L, (short)6143, (short)710 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 80L, (short)6143, (short)1910 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 15L, (short)6150, (short)820 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 86L, (short)6149, (short)2010 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 50L, (short)6149, (short)1410 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 14L, (short)6149, (short)810 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 85L, (short)6148, (short)2000 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 49L, (short)6148, (short)1400 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 13L, (short)6148, (short)800 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 84L, (short)6147, (short)1950 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 48L, (short)6147, (short)1350 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 12L, (short)6147, (short)750 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 83L, (short)6146, (short)1940 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 47L, (short)6146, (short)1340 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 11L, (short)6146, (short)740 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 82L, (short)6145, (short)1930 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 46L, (short)6145, (short)1330 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 10L, (short)6145, (short)730 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 81L, (short)6144, (short)1920 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 45L, (short)6144, (short)1320 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 9L, (short)6144, (short)720 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 44L, (short)6143, (short)1310 });

            migrationBuilder.InsertData(
                table: "RouteSchedules",
                columns: new[] { "Id", "StopNumber", "Timepoint" },
                values: new object[] { 72L, (short)6137, (short)1750 });

            migrationBuilder.CreateIndex(
                name: "IX_RouteSchedules_StopNumber",
                table: "RouteSchedules",
                column: "StopNumber");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStops_Number",
                table: "RouteStops",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RouteSchedules");

            migrationBuilder.DropTable(
                name: "RouteStops");
        }
    }
}
