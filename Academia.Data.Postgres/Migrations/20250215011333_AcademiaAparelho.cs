using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Academia.Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AcademiaAparelho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcademiaAparelhoId",
                table: "Academia",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AcademiaAparelho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcademiaId = table.Column<int>(type: "integer", nullable: false),
                    AparelhoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademiaAparelho", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Academia_AcademiaAparelhoId",
                table: "Academia",
                column: "AcademiaAparelhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Academia_AcademiaAparelho_AcademiaAparelhoId",
                table: "Academia",
                column: "AcademiaAparelhoId",
                principalTable: "AcademiaAparelho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Academia_AcademiaAparelho_AcademiaAparelhoId",
                table: "Academia");

            migrationBuilder.DropTable(
                name: "AcademiaAparelho");

            migrationBuilder.DropIndex(
                name: "IX_Academia_AcademiaAparelhoId",
                table: "Academia");

            migrationBuilder.DropColumn(
                name: "AcademiaAparelhoId",
                table: "Academia");
        }
    }
}
