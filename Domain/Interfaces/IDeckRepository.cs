using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDeckRepository:IRepository<Deck>
    {
        Task<List<Card>> GetCardsAsync( );
        Task<Deck> CreateDeckAsync( );
    }
}
