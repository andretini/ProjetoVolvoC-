using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaLocadora.Models
{
    public class VendaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenda { get; set; }

        public DateTime? DataVenda { get; set; }
        public double? ValorDeVenda { get; set; }
        public int? FkVeiculoIdVeiculo { get; set; }

        [ForeignKey("FkVeiculoIdVeiculo")]
        public virtual VeiculoModel? Veiculo { get; set; }
    }
}
