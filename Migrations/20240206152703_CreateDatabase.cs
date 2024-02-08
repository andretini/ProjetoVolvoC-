using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLocadora.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Sobrenome = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    RG = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    CPF = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Endereco = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id_Veiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Valor_de_Compra = table.Column<double>(type: "float", nullable: true),
                    Valor_Diaria = table.Column<double>(type: "float", nullable: true),
                    Ano = table.Column<int>(type: "int", nullable: true),
                    Modelo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Marca = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Placa = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Tipo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Categoria = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id_Veiculo);
                });

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    Id_Locacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVeiculo = table.Column<int>(type: "int", nullable: false),
                    Dias = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: true),
                    Data_Locacao = table.Column<DateOnly>(type: "date", nullable: true),
                    fk_Cliente_Id_Cliente = table.Column<int>(type: "int", nullable: true),
                    fk_Veiculo_Id_Veiculo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.Id_Locacao);
                    table.ForeignKey(
                        name: "FK_Locacao_2",
                        column: x => x.fk_Cliente_Id_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Locacao_3",
                        column: x => x.fk_Veiculo_Id_Veiculo,
                        principalTable: "Veiculo",
                        principalColumn: "Id_Veiculo",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id_Venda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Venda = table.Column<DateOnly>(type: "date", nullable: true),
                    Valor_Venda = table.Column<double>(type: "float", nullable: true),
                    fk_Veiculo_Id_Veiculo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id_Venda);
                    table.ForeignKey(
                        name: "FK_Venda_3",
                        column: x => x.fk_Veiculo_Id_Veiculo,
                        principalTable: "Veiculo",
                        principalColumn: "Id_Veiculo",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_fk_Cliente_Id_Cliente",
                table: "Locacao",
                column: "fk_Cliente_Id_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_fk_Veiculo_Id_Veiculo",
                table: "Locacao",
                column: "fk_Veiculo_Id_Veiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_fk_Veiculo_Id_Veiculo",
                table: "Vendas",
                column: "fk_Veiculo_Id_Veiculo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacao");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Veiculo");
        }
    }
}
