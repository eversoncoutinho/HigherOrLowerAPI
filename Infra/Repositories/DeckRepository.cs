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
            var deck = new Deck();
            var cartas = deck.CreateDeck();
            await _context.AddAsync(deck.Cards=cartas);
            return deck;
        }
        public Deck CreateDeck( )
        {
            var deck = new Deck();
            var cartas = deck.CreateDeck();
            deck.Cards = cartas;
            _context.Add(deck);
            return deck;
        }

        public async Task<Deck> GetDeckAsync(int id) => await _context.Decks.Include(c=>c.Cards).SingleOrDefaultAsync(n=>n.Id==id);
        
    }
}
