using Microsoft.AspNetCore.Mvc;
using SistemaLocadora.Data;
using SistemaLocadora.Models;
using SistemaLocadora.Repositorio;

namespace SistemaLocadora.Controllers
{
    public class AluguelController : Controller
    {
        LocadoraContext _context = new LocadoraContext();
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IAluguelRepositorio _aluguelRepositorio;
        private readonly IVeiculoRepositorio _veiculoRepositorio;
        public AluguelController(IClienteRepositorio clienteRepositorio, IAluguelRepositorio aluguelRepositorio, IVeiculoRepositorio veiculoRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _aluguelRepositorio = aluguelRepositorio;
            _veiculoRepositorio = veiculoRepositorio;
        }
        public IActionResult Index()
        {
            List<VeiculoModel> veiculos = _veiculoRepositorio.ListarVeiculo();
            return View(veiculos);
        }
        public IActionResult Devolucao()
        {
            List<LocacaoModel> locacoes = _aluguelRepositorio.ListarLocacao();
            return View(locacoes);
        }

        public IActionResult Alugar()
        {
            List<ClienteModel> li = new List<ClienteModel>();
            li = _clienteRepositorio.ListarClientes();
            ViewBag.listofitems = li;
            return View();
        }

        [HttpPost]
        public IActionResult AlugarVeiculo(LocacaoModel locacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _aluguelRepositorio.Alugar(locacao);
                    TempData["MensagemSucesso"] = "Aluguel registrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(locacao);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel locar o veiculo, tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        // ESTE HTTP POST INTEIRO E ALTERACAO
        [HttpPost]
        public IActionResult Alugar(string IdVeiculo, string Nome, string Sobrenome, string CPF, string dias)
        {
            try
            {
            
                LocacaoModel locacao = new LocacaoModel();
                locacao.IdVeiculo = Convert.ToInt32(IdVeiculo);
                locacao.Dias = Convert.ToInt32(dias);
                ClienteModel cliente = null;
                VeiculoModel veiculo = null;
                foreach(ClienteModel cli in _context.Clientes){
                    if (cli.Nome.ToLower() == Nome.ToLower() && cli.Sobrenome.ToLower() == Sobrenome.ToLower()){
                        cliente = cli;
                    }
                    else if(cli.Cpf.ToLower() == CPF.ToLower()){
                        cliente = cli;
                    }
                }
                foreach(VeiculoModel vei in _context.Veiculos){
                    if (vei.IdVeiculo == Convert.ToInt32(IdVeiculo)){
                        veiculo = vei;
                    }
                    
                }
                
                locacao.FkClienteIdCliente = cliente.IdCliente;
                _aluguelRepositorio.Alugar(locacao);
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel locar o veiculo, tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }


        [HttpPost]
        public IActionResult Devolver(string IdLocacao)
        {
            try
            {
                LocacaoModel upd = null;

                foreach(LocacaoModel locacao in _context.Locacaos){
                    System.Console.WriteLine(IdLocacao);
                    if (locacao.IdLocacao == Convert.ToInt32(IdLocacao)){
                        upd = locacao;
                    }
                }
                _aluguelRepositorio.Devolver(upd);
                return RedirectToAction("Devolucao");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel devolver o veiculo, tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Devolucao");
            }
        }
    }
}
