using System.ComponentModel.DataAnnotations;

namespace ProjetoLoja.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public DateTime Data { get; set; }

        public decimal ValorTotal { get; set; }

        public string Status { get; set; } = string.Empty;

        public string Observacao { get; set; } = string.Empty;
    }
}