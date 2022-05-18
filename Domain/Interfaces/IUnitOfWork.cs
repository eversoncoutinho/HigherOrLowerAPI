using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IChallengeRepository ChallengeRepository { get; }
         IDeckRepository DeckRepository { get; }
        IGameRepository GameRepository { get; }
        ICardRepository CardRepository { get; }
        IPlayerRepository PlayerRepository { get; }
        void Commit();
        Task CommitAsync( );
    }
}
