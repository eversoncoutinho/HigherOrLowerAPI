using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DeckService : IDeckService
    {
        public readonly IUnitOfWork _uof;
        public readonly IMapper _mapper;
        public DeckService(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public async Task<Deck> GetDeckAsync(int id) =>await _uof.DeckRepository.GetDeckAsync(id);
        public Deck CreateDeck( ) {
            
            var deck = _uof.DeckRepository.CreateDeck();
            
            return deck;
        }

        public Card ChooseCard(int id)
        {
            var deckById = _uof.DeckRepository.GetDeckAsync(id).Result;
            var rd = new Random();
            var card = new Card();

            while (true)
            {
                var remainingCards = rd.Next(0, deckById.Cards.Count);
                if (deckById.Cards [remainingCards] == null)
                    continue;
                return deckById.Cards [remainingCards];

            }
        }
        public Card ChooseCard(Deck deck)
        {
            var deckById = deck;
            var rd = new Random();
            var remainingCards = rd.Next(0, deckById.Cards.Count);
            if (remainingCards == 0) 
            {   
                //TO DO - Remove Deck
                return new Card();
            }
            var card = deckById.Cards [remainingCards];
            return card;
        }
        public async Task<Deck> DeleteCard(int DeckId, Card value)
        {

            var deckById =await _uof.DeckRepository.GetDeckAsync(DeckId);
            deckById.Cards.RemoveAll(x => x.Value == value.Value && x.Nipe==value.Nipe);
            
            _uof.DeckRepository.Update(deckById);
            _uof.Commit();

            return deckById;
        }
        public Deck RemoveCardDeck(Deck deck, Card value)
        {

            var deckById = deck;
            
            deckById.Cards.RemoveAll(x => x.Value == value.Value && x.Nipe == value.Nipe);
        
            return deckById;
        }
        public void RemoveCardDeck(Card value)
        {
            _uof.CardRepository.Delete(value);
        }
    }
}
