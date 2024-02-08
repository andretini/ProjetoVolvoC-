using SistemaLocadora.Data;
using SistemaLocadora.Models;
using System.Linq.Expressions;

namespace SistemaLocadora.Repositorio
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private readonly LocadoraContext _locadoraContext;
        public VeiculoRepositorio(LocadoraContext locadoraContext)
        {
            _locadoraContext = locadoraContext;
        }

        public VeiculoModel Adicionar(VeiculoModel veiculo)
        {
            switch(veiculo.Tipo)
            {
                case "Moto":
                    if (veiculo.Categoria == "Popular")
                    {
                        veiculo.ValorDiaria = 70;
                    }
                    else if (veiculo.Categoria == "Intermediario")
                    {
                        veiculo.ValorDiaria = 200;
                    }
                    else
                        veiculo.ValorDiaria = 350;
                    break;
                case "Automovel":
                    if (veiculo.Categoria == "Popular")
                    {
                        veiculo.ValorDiaria = 100;
                    }
                    else if (veiculo.Categoria == "Intermediario")
                    {
                        veiculo.ValorDiaria = 300;
                    }
                    else
                        veiculo.ValorDiaria = 450;
                    break;
                case "Van":
                    if (veiculo.Categoria == "Popular")
                    {
                        veiculo.ValorDiaria = 200;
                    }
                    else if (veiculo.Categoria == "Intermediario")
                    {
                        veiculo.ValorDiaria = 400;
                    }
                    else
                        veiculo.ValorDiaria = 600;
                    break;
            }
            veiculo.Estado = "Disponivel";
                        
            _locadoraContext.Veiculos.Add(veiculo);
            _locadoraContext.SaveChanges();
            return veiculo;
        }

        public VeiculoModel ListarPorId(int id)
        {
            return _locadoraContext.Veiculos.FirstOrDefault(c => c.IdVeiculo == id);
        }

        public List<VeiculoModel> ListarVeiculo()
        {
            return _locadoraContext.Veiculos.ToList();
        }

        public VendaModel Vender(VeiculoModel veiculo)
        {
            VeiculoModel veiculoDB = ListarPorId(veiculo.IdVeiculo);
            if (veiculoDB == null && veiculoDB.Estado != "Disponivel") throw new Exception("Houve um erro ao vender o veiculo");
            VendaModel venda = new VendaModel();
            venda.DataVenda = DateTime.Today;
            venda.ValorDeVenda = veiculoDB.ValorDeCompra - (venda.DataVenda.Value.Year - veiculoDB.Ano) * 0.15 * veiculoDB.ValorDeCompra;
            veiculoDB.Estado = "Vendido";
            venda.Veiculo = veiculoDB;
            _locadoraContext.Veiculos.Update(veiculoDB);
            _locadoraContext.Vendas.Add(venda);
            _locadoraContext.SaveChanges();
            return venda;
        }
    }
}
