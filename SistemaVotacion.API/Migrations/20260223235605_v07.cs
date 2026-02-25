using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaVotacion.API.Migrations
{
    /// <inheritdoc />
    public partial class v07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcesosElectorales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreProceso = table.Column<string>(type: "text", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcesosElectorales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreRol = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreCompleto = table.Column<string>(type: "text", nullable: false),
                    FotoUrl = table.Column<string>(type: "text", nullable: false),
                    ProcesoElectoralId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatos_ProcesosElectorales_ProcesoElectoralId",
                        column: x => x.ProcesoElectoralId,
                        principalTable: "ProcesosElectorales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartidosPoliticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NOmbrePartido = table.Column<string>(type: "text", nullable: false),
                    SimboloUrl = table.Column<string>(type: "text", nullable: false),
                    ProcesoElectoralId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartidosPoliticos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartidosPoliticos_ProcesosElectorales_ProcesoElectoralId",
                        column: x => x.ProcesoElectoralId,
                        principalTable: "ProcesosElectorales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Contraseña = table.Column<string>(type: "text", nullable: false),
                    Cedula = table.Column<int>(type: "integer", nullable: false),
                    RolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CandidatoId = table.Column<int>(type: "integer", nullable: false),
                    ProcesoElectoralId = table.Column<int>(type: "integer", nullable: false),
                    FechaVoto = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votos_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votos_ProcesosElectorales_ProcesoElectoralId",
                        column: x => x.ProcesoElectoralId,
                        principalTable: "ProcesosElectorales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "listas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreLista = table.Column<string>(type: "text", nullable: false),
                    ProcesoElectoralId = table.Column<int>(type: "integer", nullable: false),
                    PartidoPoliticoId = table.Column<int>(type: "integer", nullable: false),
                    CandidatoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_listas_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_listas_PartidosPoliticos_PartidoPoliticoId",
                        column: x => x.PartidoPoliticoId,
                        principalTable: "PartidosPoliticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_listas_ProcesosElectorales_ProcesoElectoralId",
                        column: x => x.ProcesoElectoralId,
                        principalTable: "ProcesosElectorales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Padrones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HaVotado = table.Column<bool>(type: "boolean", nullable: false),
                    CodigoAcceso = table.Column<string>(type: "text", nullable: true),
                    ProcesoElectoralId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padrones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Padrones_ProcesosElectorales_ProcesoElectoralId",
                        column: x => x.ProcesoElectoralId,
                        principalTable: "ProcesosElectorales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Padrones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_ProcesoElectoralId",
                table: "Candidatos",
                column: "ProcesoElectoralId");

            migrationBuilder.CreateIndex(
                name: "IX_listas_CandidatoId",
                table: "listas",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_listas_PartidoPoliticoId",
                table: "listas",
                column: "PartidoPoliticoId");

            migrationBuilder.CreateIndex(
                name: "IX_listas_ProcesoElectoralId",
                table: "listas",
                column: "ProcesoElectoralId");

            migrationBuilder.CreateIndex(
                name: "IX_Padrones_ProcesoElectoralId",
                table: "Padrones",
                column: "ProcesoElectoralId");

            migrationBuilder.CreateIndex(
                name: "IX_Padrones_UsuarioId",
                table: "Padrones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidosPoliticos_ProcesoElectoralId",
                table: "PartidosPoliticos",
                column: "ProcesoElectoralId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_CandidatoId",
                table: "Votos",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_ProcesoElectoralId",
                table: "Votos",
                column: "ProcesoElectoralId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "listas");

            migrationBuilder.DropTable(
                name: "Padrones");

            migrationBuilder.DropTable(
                name: "Votos");

            migrationBuilder.DropTable(
                name: "PartidosPoliticos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ProcesosElectorales");
        }
    }
}
