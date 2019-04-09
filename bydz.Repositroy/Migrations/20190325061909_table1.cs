using Microsoft.EntityFrameworkCore.Migrations;

namespace bydz.Repositroy.Migrations
{
    public partial class table1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "array",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    PokerId = table.Column<string>(nullable: false),
                    PokerName = table.Column<string>(maxLength: 50, nullable: true),
                    life = table.Column<double>(nullable: false),
                    Aggressivity = table.Column<double>(nullable: false),
                    Defenses = table.Column<double>(nullable: false),
                    vigour = table.Column<double>(nullable: false),
                    crits = table.Column<double>(nullable: false),
                    indomitableness = table.Column<double>(nullable: false),
                    evade = table.Column<double>(nullable: false),
                    hit = table.Column<double>(nullable: false),
                    skill = table.Column<int>(nullable: false),
                    survival = table.Column<int>(nullable: false),
                    action = table.Column<string>(nullable: true),
                    ascription = table.Column<int>(nullable: false),
                    positionX = table.Column<int>(nullable: false),
                    positionY = table.Column<int>(nullable: false),
                    level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_array", x => new { x.UserId, x.PokerId });
                });

            migrationBuilder.CreateTable(
                name: "baseInfor",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    levelG = table.Column<int>(nullable: false),
                    drawNum = table.Column<int>(nullable: false),
                    gold = table.Column<double>(nullable: false),
                    fatigueNum = table.Column<int>(nullable: false),
                    date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baseInfor", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "myPokers",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    PokerId = table.Column<string>(nullable: false),
                    PokerName = table.Column<string>(maxLength: 50, nullable: true),
                    life = table.Column<double>(nullable: false),
                    Aggressivity = table.Column<double>(nullable: false),
                    Defenses = table.Column<double>(nullable: false),
                    vigour = table.Column<double>(nullable: false),
                    crits = table.Column<double>(nullable: false),
                    indomitableness = table.Column<double>(nullable: false),
                    evade = table.Column<double>(nullable: false),
                    hit = table.Column<double>(nullable: false),
                    skill = table.Column<int>(nullable: false),
                    survival = table.Column<int>(nullable: false),
                    action = table.Column<string>(nullable: true),
                    ascription = table.Column<int>(nullable: false),
                    positionX = table.Column<int>(nullable: false),
                    positionY = table.Column<int>(nullable: false),
                    level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myPokers", x => new { x.UserId, x.PokerId });
                });

            migrationBuilder.CreateTable(
                name: "Pokers",
                columns: table => new
                {
                    PokerId = table.Column<string>(nullable: false),
                    PokerName = table.Column<string>(maxLength: 50, nullable: true),
                    life = table.Column<double>(nullable: false),
                    Aggressivity = table.Column<double>(nullable: false),
                    Defenses = table.Column<double>(nullable: false),
                    vigour = table.Column<double>(nullable: false),
                    crits = table.Column<double>(nullable: false),
                    indomitableness = table.Column<double>(nullable: false),
                    evade = table.Column<double>(nullable: false),
                    hit = table.Column<double>(nullable: false),
                    skill = table.Column<int>(nullable: false),
                    survival = table.Column<int>(nullable: false),
                    action = table.Column<string>(nullable: true),
                    ascription = table.Column<int>(nullable: false),
                    positionX = table.Column<int>(nullable: false),
                    positionY = table.Column<int>(nullable: false),
                    level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokers", x => x.PokerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "array");

            migrationBuilder.DropTable(
                name: "baseInfor");

            migrationBuilder.DropTable(
                name: "myPokers");

            migrationBuilder.DropTable(
                name: "Pokers");
        }
    }
}
