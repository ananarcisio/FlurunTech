using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InVents.Migrations
{
    /// <inheritdoc />
    public partial class NotaAlteradoMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Fornecedor_AlvoId",
                table: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_Nota_AlvoId",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "CargoCriador",
                table: "Nota");

            migrationBuilder.RenameColumn(
                name: "AlvoId",
                table: "Nota",
                newName: "ProdutorId");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Nota",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "Nota",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Nota");

            migrationBuilder.RenameColumn(
                name: "ProdutorId",
                table: "Nota",
                newName: "AlvoId");

            migrationBuilder.AddColumn<string>(
                name: "CargoCriador",
                table: "Nota",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nota_AlvoId",
                table: "Nota",
                column: "AlvoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Fornecedor_AlvoId",
                table: "Nota",
                column: "AlvoId",
                principalTable: "Fornecedor",
                principalColumn: "Id");
        }
    }
}
