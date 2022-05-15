using System.Collections.Generic;

namespace Domain.Entities
{
    public class Deck:Entity
    {
        public Deck( ) { }
        public Deck(List<Card> cards)
        {
            Cards = cards;
        }
        public List<Card> Cards { get; set; }

    }
}
