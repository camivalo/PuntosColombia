using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PuntosColombia.Web.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MissingNumbers",
                columns: table => new
                {
                    MissingNumberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuantityListA = table.Column<int>(nullable: false),
                    ListA = table.Column<string>(nullable: true),
                    QuantityListB = table.Column<int>(nullable: false),
                    ListB = table.Column<string>(nullable: true),
                    ListResult = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissingNumbers", x => x.MissingNumberId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissingNumbers");
        }
    }
}
