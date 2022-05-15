using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDeckService
    {
        /// <summary>
        /// Get The Card List in database
        /// </summary>
        /// <returns></returns>
        Task<List<Card>> GetCardsAsync( );
        /// <summary>
        /// Get the Card List in database and create Deck.
        /// </summary>
        /// <returns>return Deck Id</returns>
        Task<Deck> CreateDeckAsync( );
        Card Open(int id, List<Card> deck);
    }
}
