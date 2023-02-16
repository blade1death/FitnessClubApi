using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FitnessClubApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FitnessClub");

            migrationBuilder.CreateTable(
                name: "gruppa",
                schema: "FitnessClub",
                columns: table => new
                {
                    названиеgruppi = table.Column<string>(type: "character varying", nullable: false),
                    примечание = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("gruppa_pkey", x => x.названиеgruppi);
                });

            migrationBuilder.CreateTable(
                name: "trener",
                schema: "FitnessClub",
                columns: table => new
                {
                    identificatortrener = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    dolshnost = table.Column<string>(type: "character varying", nullable: false),
                    fio = table.Column<string>(type: "character varying", nullable: false),
                    telephone = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("trener_pkey", x => x.identificatortrener);
                });

            migrationBuilder.CreateTable(
                name: "client",
                schema: "FitnessClub",
                columns: table => new
                {
                    nomerabonimenta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    fio = table.Column<string>(type: "character varying", nullable: false),
                    dataroshdenia = table.Column<DateOnly>(type: "date", nullable: true),
                    pol = table.Column<string>(type: "character varying", nullable: true),
                    ves = table.Column<int>(type: "integer", nullable: true),
                    rost = table.Column<int>(type: "integer", nullable: true),
                    nashaloabonimenta = table.Column<DateOnly>(type: "date", nullable: true),
                    okonshanie = table.Column<DateOnly>(type: "date", nullable: false),
                    telephone = table.Column<string>(type: "character varying", nullable: false),
                    названиеgruppi = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("client_pkey", x => x.nomerabonimenta);
                    table.ForeignKey(
                        name: "client_названиеgruppi_fkey",
                        column: x => x.названиеgruppi,
                        principalSchema: "FitnessClub",
                        principalTable: "gruppa",
                        principalColumn: "названиеgruppi");
                });

            migrationBuilder.CreateTable(
                name: "raspisanie",
                schema: "FitnessClub",
                columns: table => new
                {
                    identificatorraspisania = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vidzanatii = table.Column<string>(type: "character varying", nullable: false),
                    zal = table.Column<string>(type: "character varying", nullable: true),
                    dennedeli = table.Column<string>(type: "character varying", nullable: false),
                    nachalozanatii = table.Column<DateOnly>(type: "date", nullable: false),
                    prodolshitelnost = table.Column<int>(type: "integer", nullable: false),
                    названиеgruppi = table.Column<string>(type: "character varying", nullable: false),
                    identificatortrener = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("raspisanie_pkey", x => x.identificatorraspisania);
                    table.ForeignKey(
                        name: "raspisanie_identificatortrener_fkey",
                        column: x => x.identificatortrener,
                        principalSchema: "FitnessClub",
                        principalTable: "trener",
                        principalColumn: "identificatortrener");
                    table.ForeignKey(
                        name: "raspisanie_названиеgruppi_fkey",
                        column: x => x.названиеgruppi,
                        principalSchema: "FitnessClub",
                        principalTable: "gruppa",
                        principalColumn: "названиеgruppi");
                });

            migrationBuilder.CreateIndex(
                name: "IX_client_названиеgruppi",
                schema: "FitnessClub",
                table: "client",
                column: "названиеgruppi");

            migrationBuilder.CreateIndex(
                name: "IX_raspisanie_названиеgruppi",
                schema: "FitnessClub",
                table: "raspisanie",
                column: "названиеgruppi");

            migrationBuilder.CreateIndex(
                name: "IX_raspisanie_identificatortrener",
                schema: "FitnessClub",
                table: "raspisanie",
                column: "identificatortrener");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client",
                schema: "FitnessClub");

            migrationBuilder.DropTable(
                name: "raspisanie",
                schema: "FitnessClub");

            migrationBuilder.DropTable(
                name: "trener",
                schema: "FitnessClub");

            migrationBuilder.DropTable(
                name: "gruppa",
                schema: "FitnessClub");
        }
    }
}
