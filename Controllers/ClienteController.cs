using Microsoft.AspNetCore.Mvc;
using SistemaLocadora.Models;
using SistemaLocadora.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaLocadora.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        public IActionResult Index()
        {
            List<ClienteModel> clientes = _clienteRepositorio.ListarClientes();
            return View(clientes);
        } 
        public IActionResult Criar()
        {
            return View();
        } 
        public IActionResult Editar(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id); 
            return View(cliente);
        } 
        public IActionResult Apagar(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult ApagarConf(int id)
        {
            try
            {
                bool apagado = _clienteRepositorio.Apagar(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possivel apagar o cliente.";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel apagar o cliente, tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CriarCliente(ClienteModel cliente) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }catch (System.Exception erro) 
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar o cliente, tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult EditarCliente(ClienteModel cliente) 
        {
           try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", cliente);
            }catch(System.Exception erro) 
            {
                TempData["MensagemErro"] = $"Não foi possivel alterar o cliente, tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
