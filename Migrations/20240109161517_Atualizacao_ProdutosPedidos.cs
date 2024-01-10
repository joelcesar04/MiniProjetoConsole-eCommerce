using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Console.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacao_ProdutosPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NroPedido",
                table: "ProdutosPedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NroPedido",
                table: "ProdutosPedidos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
