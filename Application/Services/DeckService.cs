using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{    
    public class DeckService : IDeckService
    {
        public readonly IUnitOfWork _uof;
        public DeckService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public Task<List<Card>> GetCardsAsync( ) => _uof.DeckRepository.GetCardsAsync();
        public Task<Deck> CreateDeckAsync( ) => _uof.DeckRepository.CreateDeckAsync();
        public Card Open(int id,List<Card> deck)
        {
            var rd = new Random();
            var number =rd.Next(0, deck.Count);
            var card = deck [number];
            return card;
            
        }
    }
}
