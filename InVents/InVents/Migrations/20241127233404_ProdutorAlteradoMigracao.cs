using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InVents.Migrations
{
    /// <inheritdoc />
    public partial class ProdutorAlteradoMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Produtor_ProdutorId",
                table: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedor_ProdutorId",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "ProdutorId",
                table: "Fornecedor");

            migrationBuilder.AddColumn<string>(
                name: "FornecedoresContratados",
                table: "Produtor",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FornecedoresContratados",
                table: "Produtor");

            migrationBuilder.AddColumn<int>(
                name: "ProdutorId",
                table: "Fornecedor",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_ProdutorId",
                table: "Fornecedor",
                column: "ProdutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Produtor_ProdutorId",
                table: "Fornecedor",
                column: "ProdutorId",
                principalTable: "Produtor",
                principalColumn: "Id");
        }
    }
}
