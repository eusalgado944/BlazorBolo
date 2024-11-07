using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolosApi.DTOs
{
    public class BoloUploadDto
    {
        public string? Nome { get; set; }
        public string? Sabor { get; set; }
        public IFormFile? Imagem { get; set; } // Arquivo de imagem para upload
        public string? Descricao { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        
    }
}
