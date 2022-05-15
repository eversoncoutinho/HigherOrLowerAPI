using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICardRepository CardRepository { get; }
        IDeckRepository DeckRepository { get; }
        void Commit();
        Task CommitAsync( );
    }
}
