using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class ChallengeRepository : Repository<Challenge>, IChallengeRepository
    {
        private readonly HigherOrLowerDbContext _context;
        public ChallengeRepository(HigherOrLowerDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Challenge> GetChallenge(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Challenge> GetChallengeAsync(int id)
        {
            return await _context.Challenges
                .Include(g => g.Games)
                .Include(p=>p.Players)
                .FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}
