using System.ComponentModel.DataAnnotations.Schema;

namespace BolosModel.Entities
{
    public class Bolo
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sabor { get; set; }
        public string? Descricao { get; set; }
        public string? ImagemUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
    }
}
