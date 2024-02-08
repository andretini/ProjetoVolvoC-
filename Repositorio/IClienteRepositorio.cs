using SistemaLocadora.Models;

namespace SistemaLocadora.Repositorio
{
    public interface IClienteRepositorio
    {
        ClienteModel Adicionar(ClienteModel cliente);
        List<ClienteModel> ListarClientes();
        ClienteModel ListarPorId(int id);
        ClienteModel Atualizar(ClienteModel cliente);
        bool Apagar(int id);
    }
}
