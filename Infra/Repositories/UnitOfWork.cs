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

        
        private DeckRepository _deckRepository;
        private GameRepository _gameRepository;
        private ChallengeRepository _challengeRepository;

        public IDeckRepository DeckRepository
        {
            get
            {
                return _deckRepository = _deckRepository ?? new DeckRepository(_context);
            }
        }
        public IGameRepository GameRepository
        {
            get
            {
                return _gameRepository = _gameRepository ?? new GameRepository(_context);
            }
        }

        public IChallengeRepository ChallengeRepository
        {
            get
            {
                return _challengeRepository = _challengeRepository ?? new ChallengeRepository(_context);
            }
        }


        public void Commit() => _context.SaveChanges();
        public async Task CommitAsync() => await _context.SaveChangesAsync();
        public void Dispose()=>_context.Dispose();  
    }
}
