using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academia.Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class required_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aparelho_Academia_AcademiaId",
                table: "Aparelho");

            migrationBuilder.AlterColumn<Guid>(
                name: "AcademiaId",
                table: "Aparelho",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Aparelho_Academia_AcademiaId",
                table: "Aparelho",
                column: "AcademiaId",
                principalTable: "Academia",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aparelho_Academia_AcademiaId",
                table: "Aparelho");

            migrationBuilder.AlterColumn<Guid>(
                name: "AcademiaId",
                table: "Aparelho",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Aparelho_Academia_AcademiaId",
                table: "Aparelho",
                column: "AcademiaId",
                principalTable: "Academia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
