using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaLocadora.Models
{
    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Required(ErrorMessage ="Informe o nome do cliente")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Informe o sobrenome do cliente")]
        public string? Sobrenome { get; set; }
        [Required(ErrorMessage = "Informe o RG do cliente")]
        public string? Rg { get; set; }
        [Required(ErrorMessage = "Informe o CPF do cliente")]
        public string? Cpf { get; set; }

        public string? Endereco { get; set; }

        public virtual ICollection<LocacaoModel> Locacaos { get; set; } = new List<LocacaoModel>();
    }
}
