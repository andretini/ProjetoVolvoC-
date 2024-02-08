using SistemaLocadora.Data;
using SistemaLocadora.Models;

namespace SistemaLocadora.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly LocadoraContext _locadoraContext;
        public ClienteRepositorio(LocadoraContext locadoraContext) 
        {
            _locadoraContext = locadoraContext;
        }
        public ClienteModel Adicionar(ClienteModel cliente)
        {
            _locadoraContext.Clientes.Add(cliente);
            _locadoraContext.SaveChanges();
            return cliente;
        }

        public bool Apagar(int id)
        {
            ClienteModel clienteDB = ListarPorId(id);
            if (clienteDB == null) throw new Exception("Houve um erro ao apagar o cliente");

            _locadoraContext.Clientes.Remove(clienteDB);
            _locadoraContext.SaveChanges();
            return true;
        }

        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel clienteDB = ListarPorId(cliente.IdCliente);
            if (clienteDB == null) throw new Exception("Houve um erro na atualização do cliente");

            clienteDB.Nome = cliente.Nome;
            clienteDB.Sobrenome = cliente.Sobrenome;
            clienteDB.Cpf = cliente.Cpf;
            clienteDB.Rg = cliente.Rg;
            clienteDB.Endereco = cliente.Endereco;
            _locadoraContext.Clientes.Update(clienteDB);
            _locadoraContext.SaveChanges();
            return clienteDB;
        }

        public List<ClienteModel> ListarClientes()
        {
            return _locadoraContext.Clientes.ToList();
        }

        public ClienteModel ListarPorId(int id)
        {

            return _locadoraContext.Clientes.FirstOrDefault(c => c.IdCliente == id);

        }
    }
}
