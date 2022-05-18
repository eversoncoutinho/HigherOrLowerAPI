using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDeckRepository:IRepository<Deck>
    {
        Task<Deck> GetDeckAsync(int id);
        Task<Deck> CreateDeckAsync( );
        Deck CreateDeck( );
    }
}
