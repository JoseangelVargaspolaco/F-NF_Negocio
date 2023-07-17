using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F_NF_Negocio.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Preguntas_Respuestas",
                columns: table => new
                {
                    PreguntaR_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Preguntas = table.Column<string>(type: "TEXT", nullable: true),
                    Respuestas = table.Column<bool>(type: "INTEGER", nullable: false),
                    Explicacion = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas_Respuestas", x => x.PreguntaR_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preguntas_Respuestas");
        }
    }
}
