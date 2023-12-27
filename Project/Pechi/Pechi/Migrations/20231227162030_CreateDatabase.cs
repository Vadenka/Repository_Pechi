using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pechi.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataRows",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: true),
                    RasH = table.Column<int>(type: "INTEGER", nullable: false),
                    RasTm = table.Column<int>(type: "INTEGER", nullable: false),
                    RasTg = table.Column<int>(type: "INTEGER", nullable: false),
                    RasV = table.Column<float>(type: "REAL", nullable: false),
                    RasTemG = table.Column<float>(type: "REAL", nullable: false),
                    RasRas = table.Column<float>(type: "REAL", nullable: false),
                    RasTemM = table.Column<float>(type: "REAL", nullable: false),
                    RasTepl = table.Column<int>(type: "INTEGER", nullable: false),
                    RasD = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataRows", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataRows");
        }
    }
}
