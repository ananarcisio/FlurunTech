using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InVents.Migrations
{
    /// <inheritdoc />
    public partial class ImagemFornecedorTipoAlteradoMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtor_Empresa_EmpresaId1",
                table: "Produtor");

            migrationBuilder.DropIndex(
                name: "IX_Produtor_EmpresaId1",
                table: "Produtor");

            migrationBuilder.DropColumn(
                name: "EmpresaId1",
                table: "Produtor");

            migrationBuilder.RenameColumn(
                name: "Imagens",
                table: "Fornecedor",
                newName: "Imagem");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Produtor",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtor_EmpresaId",
                table: "Produtor",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtor_Empresa_EmpresaId",
                table: "Produtor",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtor_Empresa_EmpresaId",
                table: "Produtor");

            migrationBuilder.DropIndex(
                name: "IX_Produtor_EmpresaId",
                table: "Produtor");

            migrationBuilder.RenameColumn(
                name: "Imagem",
                table: "Fornecedor",
                newName: "Imagens");

            migrationBuilder.AlterColumn<string>(
                name: "EmpresaId",
                table: "Produtor",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId1",
                table: "Produtor",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtor_EmpresaId1",
                table: "Produtor",
                column: "EmpresaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtor_Empresa_EmpresaId1",
                table: "Produtor",
                column: "EmpresaId1",
                principalTable: "Empresa",
                principalColumn: "Id");
        }
    }
}
