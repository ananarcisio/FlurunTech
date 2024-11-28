using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InVents.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtor_Empresa_EmpresaId",
                table: "Produtor");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtor_Produtor_ProdutorId",
                table: "Produtor");

            migrationBuilder.DropIndex(
                name: "IX_Produtor_EmpresaId",
                table: "Produtor");

            migrationBuilder.RenameColumn(
                name: "ProdutorId",
                table: "Produtor",
                newName: "EmpresaId1");

            migrationBuilder.RenameIndex(
                name: "IX_Produtor_ProdutorId",
                table: "Produtor",
                newName: "IX_Produtor_EmpresaId1");

            migrationBuilder.AlterColumn<string>(
                name: "EmpresaId",
                table: "Produtor",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtor_Empresa_EmpresaId1",
                table: "Produtor",
                column: "EmpresaId1",
                principalTable: "Empresa",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtor_Empresa_EmpresaId1",
                table: "Produtor");

            migrationBuilder.RenameColumn(
                name: "EmpresaId1",
                table: "Produtor",
                newName: "ProdutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtor_EmpresaId1",
                table: "Produtor",
                newName: "IX_Produtor_ProdutorId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Produtor_Produtor_ProdutorId",
                table: "Produtor",
                column: "ProdutorId",
                principalTable: "Produtor",
                principalColumn: "Id");
        }
    }
}
