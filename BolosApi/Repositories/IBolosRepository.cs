using BolosModel.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BolosApi.Repositories
{
    public interface IBoloRepository
    {
        Task<IEnumerable<Bolo>> GetAll();
        Task<Bolo?> GetById(int id);
    }
}
