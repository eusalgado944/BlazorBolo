using BolosApi.Data;
using BolosModel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolosApi.Repositories
{
    public class BoloRepository : IBoloRepository
    {
        private readonly BolosDbContext _context;

        public BoloRepository(BolosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bolo>> GetAll()
        {
            return await _context.Bolos.ToListAsync();
        }

        public async Task<Bolo?> GetById(int id)
        {
            return await _context.Bolos.FindAsync(id);
        }
    }
}
