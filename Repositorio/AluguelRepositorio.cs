using SistemaLocadora.Data;
using SistemaLocadora.Models;

namespace SistemaLocadora.Repositorio
{
    public class AluguelRepositorio : IAluguelRepositorio
    {
        private readonly LocadoraContext _locadoraContext;
        public AluguelRepositorio(LocadoraContext locadoraContext)
        {
            _locadoraContext = locadoraContext;
        }
        public LocacaoModel Alugar(LocacaoModel locacao)
        {
            //alteraçao
            VeiculoModel veiculoDB = ListarPorIdVeic(locacao.IdVeiculo);
            System.Console.WriteLine("TESTE3");
            //if (veiculoDB != null && veiculoDB.Estado == "Disponivel") throw new Exception("Houve um erro ao vender o veiculo");
            veiculoDB.Estado = "Locado";
            //alteracao
            locacao.Valor = veiculoDB.ValorDiaria * locacao.Dias;
            //alteracao
            locacao.DataLocacao = DateTime.Now.Date;
            System.Console.WriteLine("TESTE3");
            _locadoraContext.Veiculos.Update(veiculoDB);
            _locadoraContext.Locacaos.Add(locacao);
            _locadoraContext.SaveChanges();
            return locacao;

        }

        public LocacaoModel Devolver(LocacaoModel locacao)
        {
            VeiculoModel veiculoDB = ListarPorIdVeic(locacao.IdVeiculo);
            veiculoDB.Estado = "Disponivel";
            //alteracao
            locacao.DataLocacao = null;
            _locadoraContext.Veiculos.Update(veiculoDB);
            _locadoraContext.Locacaos.Update(locacao);
            _locadoraContext.SaveChanges();
            return locacao;
        }

        public List<LocacaoModel> ListarLocacao()
        {
            return _locadoraContext.Locacaos.ToList();
        }

        public LocacaoModel ListarPorId(int id)
        {
            return _locadoraContext.Locacaos.FirstOrDefault(c => c.IdLocacao == id);
        }
        public VeiculoModel ListarPorIdVeic(int id)
        {
            //alteracao{
            foreach (VeiculoModel veiculoModel in _locadoraContext.Veiculos)
            {
                if (veiculoModel.IdVeiculo == id)
                {
                    return veiculoModel;
                }
            }
            //alteraçao}
            return null;

        }
    }
}
