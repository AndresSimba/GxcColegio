using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colegios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    tipoColegio = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colegios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdColegio = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    numeroEstudiantes = table.Column<int>(type: "int", nullable: false),
                    docenteAsignado = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    curso = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    parparalelo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materias_Colegios_IdColegio",
                        column: x => x.IdColegio,
                        principalTable: "Colegios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdColegio = table.Column<int>(type: "int", nullable: false),
                    IdMateria = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    CalificacionValor = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Colegios_IdColegio",
                        column: x => x.IdColegio,
                        principalTable: "Colegios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Materias_IdMateria",
                        column: x => x.IdMateria,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calificaciones_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_IdColegio",
                table: "Calificaciones",
                column: "IdColegio");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_IdMateria",
                table: "Calificaciones",
                column: "IdMateria");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_IdUsuario",
                table: "Calificaciones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Colegios_Nombre",
                table: "Colegios",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materias_IdColegio",
                table: "Materias",
                column: "IdColegio");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Nombre",
                table: "Materias",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calificaciones");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Colegios");
        }
    }
}
