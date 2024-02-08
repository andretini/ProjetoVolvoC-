using SistemaLocadora.Models;

namespace SistemaLocadora.Repositorio
{
    public interface IAluguelRepositorio
    {
        LocacaoModel Alugar(LocacaoModel locacao);
        List<LocacaoModel> ListarLocacao();
        LocacaoModel ListarPorId(int id);
        LocacaoModel Devolver(LocacaoModel locacao);
        public VeiculoModel ListarPorIdVeic(int id);
    }
}
