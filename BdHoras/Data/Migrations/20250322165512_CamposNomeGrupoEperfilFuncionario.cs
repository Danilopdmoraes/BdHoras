using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BdHoras.Data.Migrations
{
    /// <inheritdoc />
    public partial class CamposNomeGrupoEperfilFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeGrupo",
                table: "TB_Gestores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "NomeGrupo",
                table: "TB_Funcionarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerfilFuncionario",
                table: "TB_Funcionarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeGrupo",
                table: "TB_Funcionarios");

            migrationBuilder.DropColumn(
                name: "PerfilFuncionario",
                table: "TB_Funcionarios");

            migrationBuilder.AlterColumn<string>(
                name: "NomeGrupo",
                table: "TB_Gestores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
