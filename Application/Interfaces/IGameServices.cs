using Domain.Entities;
using Domain.Enum;

namespace Application.Interfaces
{
    public interface IGameServices
    {/// <summary>
    /// Compair Card on table and Card choose on deck
    /// </summary>
    /// <param name="cardInTable"></param>
    /// <param name="cardInDeck"></param>
    /// <returns>Return Higher (1) or Lower(0)</returns>
        int CompairCards(Card cardInTable, Card cardInDeck);
        /// <summary>
        /// Compair the compair Cards and the Player's choose
        /// </summary>
        /// <param name="compairCards"></param>
        /// <param name="palyerChoose"></param>
        /// <returns>true or false</returns>
        bool CompairChoose(Guess compairCards, Guess playerChoose);
        /// <summary>
        /// Sum player's Score by 1 if compair choose is true and 0 if false
        /// </summary>
        /// <param name="player"></param>
        /// <param name="resultCompair"></param>
        /// <returns>Player's score (int)</returns>
        int AddPoint(Player player, bool resultCompair);

        
        Player PlayerTurn(Player player);
    }
}
