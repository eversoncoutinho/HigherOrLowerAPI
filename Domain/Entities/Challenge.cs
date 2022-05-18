using System.Collections.Generic;

namespace Domain.Entities
{
    public class Challenge:Entity
    {
        public Challenge(){}
        public Challenge(List<Player> players, 
            List<Game> games, 
            Deck deck)
        {
            Players = players;
            Games = games;
            Deck = deck;
        }
        public Deck Deck { get; set; }
        public List<Player> Players { get; set; }
        public List<Game> Games { get; set; }
    }
}
