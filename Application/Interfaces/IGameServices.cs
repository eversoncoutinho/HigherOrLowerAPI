using Domain.Domain;
using Domain.Entities;
using Domain.Enum;

namespace Application.Interfaces
{
    public interface IGameServices
    {
        string CompairCards(Card cardInTable, Card cardInDeck);
        bool CompairChoose(string compairCards, Guess palyerChoose);

        int AddPoint(Player player, bool resultCompair);
        //pegar o deck
        //apresentar carta
        //comparar as cartas
        //retirar carta
        //verificar se a quatidade do deck é = 0
    }
}
