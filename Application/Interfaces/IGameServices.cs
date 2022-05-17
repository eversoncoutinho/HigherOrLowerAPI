using Domain.Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGameServices
    {
        string CompairCards(Card cardInTable, Card cardInDeck);
        bool CompairChoose(string compairCards, string palyerChoose);

        int AddPoint(int platerId, bool resultCompair);
        //pegar o deck
        //apresentar carta
        //comparar as cartas
        //retirar carta
        //verificar se a quatidade do deck é = 0
    }
}
