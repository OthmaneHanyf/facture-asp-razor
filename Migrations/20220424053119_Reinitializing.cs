using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace facture.Migrations
{
    public partial class Reinitializing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    raisonSociale = table.Column<string>(type: "text", nullable: false),
                    typeSociete = table.Column<string>(type: "text", nullable: true),
                    idFiscal = table.Column<int>(type: "integer", nullable: false),
                    registreCommerce = table.Column<int>(type: "integer", nullable: false),
                    patente = table.Column<int>(type: "integer", nullable: false),
                    idCommunEntreprise = table.Column<int>(type: "integer", nullable: false),
                    nomRespo = table.Column<string>(type: "text", nullable: true),
                    nom = table.Column<string>(type: "text", nullable: true),
                    prenom = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    tel = table.Column<string>(type: "text", nullable: true),
                    adresse = table.Column<string>(type: "text", nullable: true),
                    fax = table.Column<string>(type: "text", nullable: true),
                    portable = table.Column<string>(type: "text", nullable: true),
                    ville = table.Column<string>(type: "text", nullable: true),
                    pays = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    factureNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    designation = table.Column<string>(type: "text", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: false),
                    quantite = table.Column<int>(type: "integer", nullable: false),
                    prix = table.Column<double>(type: "double precision", nullable: false),
                    tva = table.Column<int>(type: "integer", nullable: false),
                    clientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.factureNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Factures");
        }
    }
}
