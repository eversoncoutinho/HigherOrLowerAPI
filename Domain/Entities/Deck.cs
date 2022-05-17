using Domain.Domain;
using Domain.Enum;
using Domain.ValueObjects;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Deck:Entity
    {
        public Deck( ) {
            
        }
        public Deck(List<Card> cards)
        {
            Cards = cards;
        }
        public List<Card> Cards { get; set; }
        public List<Card> CreateDeck( )
        {

            var deck = new List<Card>();

            //script to create the deck with 52 card in database. jokey=11, queen=12, king=13 and ace=14
            for (int value = 2; value < 15; value++)
            {
                for (int nipe = 0; nipe <= 3; nipe++)
                {
                    //                 deck.Add(card);
                    deck.Add(new Card($"{value}", (Nipe)nipe));
                }
            }

            return deck;
        }

    }
}
