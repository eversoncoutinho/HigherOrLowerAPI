using Domain.Enum;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Game:Entity
    {
        public Game(Card cardOpen, List<Card> deck, Guess guesses)
        {
            CardOpen = cardOpen;
            Deck = deck;
            Guess = guesses;
        }

        public Card CardOpen { get; set; }
        public Guess Guess { get; set; }
        public List<Card> Deck { get; set; }

        //pegar o deck
        //apresentar carta
        //comparar as cartas
        //retirar carta
        //verificar se a quatidade do deck é = 0
    }
}
