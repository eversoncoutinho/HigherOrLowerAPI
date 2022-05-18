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


        public async Task<Challenge> GetChallengeAsync(int id)
        {
            return await _context.Challenges.Include(d=>d.Deck)
                .Include(g => g.Games)
                .Include(p=>p.Players)
                .FirstOrDefaultAsync(n => n.Id == id);
        }
        public Challenge GetChallenge(int id)
        {
            var result = _context.Challenges
                .Include(d => d.Deck.Cards)
                .Include(p => p.Players)
                .Include(g => g.Games)

                .FirstOrDefault(n => n.Id == id);
                
                //.SingleOrDefault(n => n.Id == id)
                
            

                
            return result;
            //return _context.Challenges.Include(d => d.Deck)
            //   .Include(g => g.Games)
            //   .Include(p => p.Players)
            //   .SingleOrDefault(n => n.Id == id);
        }
    }
}
