using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        private readonly HigherOrLowerDbContext _context;

        public PlayerRepository(HigherOrLowerDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Player> GetPlayerChallenge(int challegeId)
        {
            var players = _context.Challenges.FirstOrDefault(n=>n.Id==challegeId).Players;//.Where(n=>n.Id==challegeId);
            return players;
        }
    }
}
