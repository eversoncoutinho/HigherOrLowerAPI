using Domain.Domain;
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
        Task<Deck> GetDeckAsync(int id);
        /// <summary>
        /// Get the Card List in database and create Deck.
        /// </summary>
        /// <returns>return Deck Id</returns>
        Deck CreateDeck( );
        /// <summary>
        /// Get the deck created by Id
        /// </summary>
        /// <param name="id"></param>
        
        /// <returns>Card</returns>
        Card ChooseCard(int id);
        Card ChooseCard(Deck deck);
        Task<Deck> DeleteCard(int DeckId, Card value);
        Deck RemoveCardDeck(Deck deck, Card value);
    }
}
