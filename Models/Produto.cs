using System.ComponentModel.DataAnnotations;

namespace ProjetoLoja.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        [Required]
        public decimal Preco { get; set; }

        public int Estoque { get; set; }

        public string Categoria { get; set; } = string.Empty;
    }
}