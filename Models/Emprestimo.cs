using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistemas_de_emprestimos_de_livro.Models
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }

        [Display(Name = "Data do Empréstimo")]
        [DataType(DataType.Date)]
        public DateTime DataEmprestimo { get; set; }

        [Display(Name = "Devolução Prevista")]
        [DataType(DataType.Date)]
        public DateTime DataDevolucaoPrevista { get; set; }

        [Display(Name = "Quantidade de Renovações")]
        public int QuantidadeRenovacoes { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }


        [Display(Name = "Nome do Livro")]
        public int LivroId { get; set; }
        public Livro? Livro { get; set; }

        [Display(Name = "Nome do Usuario")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
