using SistemaLocadora.Models;

namespace SistemaLocadora.Repositorio
{
    public interface IVeiculoRepositorio
    {
        VeiculoModel Adicionar(VeiculoModel veiculo);
        List<VeiculoModel> ListarVeiculo();
        VeiculoModel ListarPorId(int id);
        VendaModel Vender(VeiculoModel veiculo);

    }
}
