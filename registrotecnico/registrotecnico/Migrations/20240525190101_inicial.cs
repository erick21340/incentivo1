using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace registrotecnico.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tecnicos",
                columns: table => new
                {
                    TecnicosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombres = table.Column<string>(type: "TEXT", nullable: false),
                    sueldohoras = table.Column<float>(type: "REAL", nullable: false),
                    Tecnicotipos = table.Column<string>(type: "TEXT", nullable: true),
                    tipoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tecnicos", x => x.TecnicosId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tecnicos");
        }
    }
}
