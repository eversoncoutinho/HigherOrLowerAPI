using Domain.Interfaces;
using Infra.Data;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public HigherOrLowerDbContext _context;
        UnitOfWork( ) { }
        public UnitOfWork(HigherOrLowerDbContext contexto)
        {
            _context = contexto;
        }

        private CardRepository _cardRepository;
        private DeckRepository _deckRepository;

        public ICardRepository CardRepository 
        {
            get
            {
              return _cardRepository = _cardRepository ?? new CardRepository(_context);
            }
        }

        public IDeckRepository DeckRepository
        {
            get
            {
                return _deckRepository = _deckRepository ?? new DeckRepository(_context);
            }
        }

        public void Commit() => _context.SaveChanges();
        public async Task CommitAsync() => await _context.SaveChangesAsync();
        public void Dispose()=>_context.Dispose();  
    }
}
