using Domain.Domain;
using Domain.Enum;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Game:Entity
    {
        public Game()
        {
            
        }
        public Game(Deck deck, Card cardOnTable, Guess guesses = 0, int score = 0)
        {
            Deck = deck;
            Guess = guesses;
            CardOnTable = cardOnTable;            
        }
        public Card CardOnTable { get; set; }
        public Guess Guess { get; set; }
        public Deck Deck { get; set; }
        public bool Result { get; set; }
        
        //pegar o deck
        //apresentar carta
        //comparar as cartas
        //retirar carta
        //verificar se a quatidade do deck é = 0
    }
}
