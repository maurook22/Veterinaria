using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pericles.Migrations
{
    public partial class PericlesContextPericlesContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "duenios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Dni = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Mail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_duenios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "veterinarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Mail = table.Column<string>(nullable: false),
                    Matricula = table.Column<string>(maxLength: 10, nullable: false),
                    Telefono = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "mascotas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Raza = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    TipoAnimal = table.Column<int>(nullable: false),
                    DuenioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mascotas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_mascotas_duenios_DuenioID",
                        column: x => x.DuenioID,
                        principalTable: "duenios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "consultas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Diagnostico = table.Column<string>(nullable: false),
                    MascotaID = table.Column<int>(nullable: false),
                    VeterinarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_consultas_mascotas_MascotaID",
                        column: x => x.MascotaID,
                        principalTable: "mascotas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_consultas_veterinarios_VeterinarioID",
                        column: x => x.VeterinarioID,
                        principalTable: "veterinarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_consultas_MascotaID",
                table: "consultas",
                column: "MascotaID");

            migrationBuilder.CreateIndex(
                name: "IX_consultas_VeterinarioID",
                table: "consultas",
                column: "VeterinarioID");

            migrationBuilder.CreateIndex(
                name: "IX_mascotas_DuenioID",
                table: "mascotas",
                column: "DuenioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consultas");

            migrationBuilder.DropTable(
                name: "mascotas");

            migrationBuilder.DropTable(
                name: "veterinarios");

            migrationBuilder.DropTable(
                name: "duenios");
        }
    }
}
