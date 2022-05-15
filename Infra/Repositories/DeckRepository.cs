using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class DeckRepository : Repository<Deck>, IDeckRepository
    {
        private readonly HigherOrLowerDbContext _context;
        public DeckRepository(HigherOrLowerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Deck> CreateDeckAsync( )
        {
            var cards = await _context.Cards.ToListAsync();
            var deck = new Deck(cards)
            {
                Cards = cards
            };
            return deck;
        }


        public async Task<List<Card>> GetCardsAsync( ) => await _context.Cards.ToListAsync();
        
    }
}
