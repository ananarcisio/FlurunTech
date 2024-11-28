using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InVents.Migrations
{
    /// <inheritdoc />
    public partial class mediaNotaAlteradoMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MediaNota",
                table: "Fornecedor",
                type: "REAL",
                nullable: true,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaNota",
                table: "Fornecedor");
        }
    }
}
