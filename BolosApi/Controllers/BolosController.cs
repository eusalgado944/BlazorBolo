using BolosApi.Data;
using BolosApi.DTOs;          // Namespace para o DTO BoloUploadDto
using BolosModel.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace BolosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BolosController : ControllerBase
    {
        private readonly BolosDbContext _context;

        public BolosController(BolosDbContext context)
        {
            _context = context;
        }

        // GET: api/bolos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bolo>>> GetBolos()
        {
            return await _context.Bolos.ToListAsync();
        }

        // GET: api/bolos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Bolo>> GetBolo(int id)
        {
            var bolo = await _context.Bolos.FindAsync(id);

            if (bolo == null)
            {
                return NotFound();
            }

            return bolo;
        }

        // POST: api/bolos/upload - Adiciona um novo bolo com upload de imagem
        [HttpPost("upload")]
        public async Task<ActionResult<Bolo>> PostBoloWithImage([FromForm] BoloUploadDto boloDto)
        {
            var bolo = new Bolo
            {
                Nome = boloDto.Nome,
                Sabor = boloDto.Sabor,
                Descricao = boloDto.Descricao,
                Valor = boloDto.Valor
            };

            // Verifica e salva a imagem
            if (boloDto.Imagem != null)
            {
                var uploadsFolder = Path.Combine("wwwroot", "imagens");
                Directory.CreateDirectory(uploadsFolder); // Cria a pasta se não existir

                var uniqueFileName = $"{Guid.NewGuid()}_{boloDto.Imagem.FileName}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await boloDto.Imagem.CopyToAsync(stream);
                }

                bolo.ImagemUrl = $"/imagens/{uniqueFileName}"; // Salva o caminho para a imagem
            }

            _context.Bolos.Add(bolo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBolo), new { id = bolo.Id }, bolo);
        }

        // POST: api/bolos - Adiciona um novo bolo sem upload de imagem
        [HttpPost]
        public async Task<ActionResult<Bolo>> PostBolo(Bolo bolo)
        {
            bolo.Id = 0;

            _context.Bolos.Add(bolo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBolo), new { id = bolo.Id }, bolo);
        }

        // PUT: api/bolos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBolo(int id, Bolo bolo)
        {
            if (id != bolo.Id)
            {
                return BadRequest();
            }

            _context.Entry(bolo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/bolos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBolo(int id)
        {
            var bolo = await _context.Bolos.FindAsync(id);
            if (bolo == null)
            {
                return NotFound();
            }

            // Remove a imagem do servidor se existir
            if (!string.IsNullOrEmpty(bolo.ImagemUrl))
            {
                var imagePath = Path.Combine("wwwroot", bolo.ImagemUrl.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _context.Bolos.Remove(bolo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoloExists(int id)
        {
            return _context.Bolos.Any(e => e.Id == id);
        }
    }
}
