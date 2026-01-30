using System.ComponentModel.DataAnnotations;

namespace Sistemas_de_emprestimos_de_livro.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição da categoria é obrigatória.")]
        public string Descricao { get; set; }

    }
}
