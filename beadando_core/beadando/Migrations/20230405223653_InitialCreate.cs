using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace beadando.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "kutatasok",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nev = table.Column<string>(type: "longtext", nullable: false),
                    kezdet = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    veg = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    elvartKitoltes = table.Column<int>(type: "int", nullable: false),
                    kapottKitoltes = table.Column<int>(type: "int", nullable: false),
                    aktivalva = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kutatasok", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "kerdesek",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    szoveg = table.Column<string>(type: "longtext", nullable: false),
                    Kutatas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kerdesek", x => x.ID);
                    table.ForeignKey(
                        name: "FK_kerdesek_kutatasok_Kutatas",
                        column: x => x.Kutatas,
                        principalTable: "kutatasok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "valaszok",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    szoveg = table.Column<string>(type: "longtext", nullable: false),
                    Kerdes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valaszok", x => x.ID);
                    table.ForeignKey(
                        name: "FK_valaszok_kerdesek_Kerdes",
                        column: x => x.Kerdes,
                        principalTable: "kerdesek",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "kitoltesek",
                columns: table => new
                {
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    KerdesID = table.Column<int>(type: "int", nullable: false),
                    Kutatas = table.Column<int>(type: "int", nullable: false),
                    nem = table.Column<string>(type: "longtext", nullable: false),
                    vegzettseg = table.Column<string>(type: "longtext", nullable: false),
                    kor = table.Column<int>(type: "int", nullable: false),
                    KitoltesIdo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Valasz = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitoltesek", x => new { x.email, x.KerdesID });
                    table.ForeignKey(
                        name: "FK_kitoltesek_kerdesek_KerdesID",
                        column: x => x.KerdesID,
                        principalTable: "kerdesek",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitoltesek_kutatasok_Kutatas",
                        column: x => x.Kutatas,
                        principalTable: "kutatasok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitoltesek_valaszok_Valasz",
                        column: x => x.Valasz,
                        principalTable: "valaszok",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_kerdesek_Kutatas",
                table: "kerdesek",
                column: "Kutatas");

            migrationBuilder.CreateIndex(
                name: "IX_kitoltesek_KerdesID",
                table: "kitoltesek",
                column: "KerdesID");

            migrationBuilder.CreateIndex(
                name: "IX_kitoltesek_Kutatas",
                table: "kitoltesek",
                column: "Kutatas");

            migrationBuilder.CreateIndex(
                name: "IX_kitoltesek_Valasz",
                table: "kitoltesek",
                column: "Valasz");

            migrationBuilder.CreateIndex(
                name: "IX_valaszok_Kerdes",
                table: "valaszok",
                column: "Kerdes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kitoltesek");

            migrationBuilder.DropTable(
                name: "valaszok");

            migrationBuilder.DropTable(
                name: "kerdesek");

            migrationBuilder.DropTable(
                name: "kutatasok");
        }
    }
}
