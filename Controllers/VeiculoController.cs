using Microsoft.AspNetCore.Mvc;
using SistemaLocadora.Models;
using SistemaLocadora.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaLocadora.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculoRepositorio _veiculoRepositorio;
        public VeiculoController(IVeiculoRepositorio veiculoRepositorio)
        {
            _veiculoRepositorio = veiculoRepositorio;
        }
        public IActionResult Index()
        {
            List<VeiculoModel> veiculos = _veiculoRepositorio.ListarVeiculo();
            return View(veiculos);
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        public IActionResult Venda()
        {
            List<VeiculoModel> veiculos = _veiculoRepositorio.ListarVeiculo();
            return View(veiculos);
        }
        public IActionResult Vender(int id)
        {
            VeiculoModel veiculo = _veiculoRepositorio.ListarPorId(id);
            return View(veiculo);
            
        }

        [HttpPost]
        public IActionResult VenderVeiculo(VeiculoModel veiculo) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _veiculoRepositorio.Vender(veiculo);
                    TempData["MensagemSucesso"] = "Veiculo vendido com sucesso";
                    return RedirectToAction("Index");
                }

                return View(veiculo);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel vender o veiculo, tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }    

        [HttpPost]
        public IActionResult CadastrarVeiculo(VeiculoModel veiculo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _veiculoRepositorio.Adicionar(veiculo);
                    TempData["MensagemSucesso"] = "Veiculo cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(veiculo);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel cadastrar o veiculo, tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}
