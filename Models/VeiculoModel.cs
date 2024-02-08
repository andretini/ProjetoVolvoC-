using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SistemaLocadora.Models
{
    public class VeiculoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVeiculo { get; set; }
        public string? Estado { get; set; }

        [Required(ErrorMessage = "Informe o valor de compra")]
        public double? ValorDeCompra { get; set; }
        public double? ValorDiaria { get; set; }
        [Required(ErrorMessage = "Informe o ano")]
        public int? Ano { get; set; }
        [Required(ErrorMessage = "Informe o modelo")]
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "Informe a marca")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "Informe a placa")]
        public string? Placa { get; set; }
        [Required(ErrorMessage = "Selecione o tipo")]
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "Selecione a categoria")]
        public string? Categoria { get; set; }
        public virtual ICollection<LocacaoModel> Locacaos { get; set; } = new List<LocacaoModel>();
        public virtual ICollection<VendaModel> Venda { get; set; } = new List<VendaModel>();
    }
}
