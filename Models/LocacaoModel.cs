using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLocadora.Models
{
    public class LocacaoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLocacao { get; set; }
        public int IdVeiculo { get; set; }
        [Required(ErrorMessage = "Informe os dias a alugar")]
        public int? Dias { get; set; }
        public double? Valor { get; set; }
        public DateTime? DataLocacao { get; set; }
        public int? FkClienteIdCliente { get; set; }
        public int? FkVeiculoIdVeiculo { get; set; }

        [ForeignKey("FkClienteIdCliente")]
        public virtual ClienteModel? Cliente { get; set; }

        [ForeignKey("FkVeiculoIdVeiculo")]
        public virtual VeiculoModel? Veiculo { get; set; }
    }
}
