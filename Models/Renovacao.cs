using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistemas_de_emprestimos_de_livro.Models
{
    public class Renovacao
    {
        public int RenovacaoId { get; set; }

        [Display(Name = "Data da Renovação")]
        [DataType(DataType.Date)]
        public DateTime DataRenovacao { get; set; }

        [Display(Name = "Nova Data de Devolução")]
        [DataType(DataType.Date)]
        public DateTime NovaDataDevolucao { get; set; }

        [Display(Name = "Empréstimo")]
        public int EmprestimoId { get; set; }
        public Emprestimo? Emprestimo { get; set; }
    }
}
