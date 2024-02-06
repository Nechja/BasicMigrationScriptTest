using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BasicMigration.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Llamas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Llamas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HatLlamas",
                columns: table => new
                {
                    HatsId = table.Column<int>(type: "integer", nullable: false),
                    LlamasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HatLlamas", x => new { x.HatsId, x.LlamasId });
                    table.ForeignKey(
                        name: "FK_HatLlamas_Hats_HatsId",
                        column: x => x.HatsId,
                        principalTable: "Hats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HatLlamas_Llamas_LlamasId",
                        column: x => x.LlamasId,
                        principalTable: "Llamas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hats",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { 1, "Black", "Top Hat" },
                    { 2, "Brown", "Cowboy Hat" },
                    { 3, "Red", "Baseball Cap" }
                });

            migrationBuilder.InsertData(
                table: "Llamas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Larry" },
                    { 2, "Lucy" },
                    { 3, "Leroy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HatLlamas_LlamasId",
                table: "HatLlamas",
                column: "LlamasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HatLlamas");

            migrationBuilder.DropTable(
                name: "Hats");

            migrationBuilder.DropTable(
                name: "Llamas");
        }
    }
}
