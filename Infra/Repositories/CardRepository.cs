using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        private readonly HigherOrLowerDbContext _context;
        public CardRepository(HigherOrLowerDbContext context) : base(context)
        {
            _context = context;
        }
        /// <summary>
        /// </summary>
        /// <returns>Card List</returns>
        public async Task<List<Card>> Cards( ) => await _context.Cards.ToListAsync();
        
    }
}
