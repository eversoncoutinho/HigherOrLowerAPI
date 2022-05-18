using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;

namespace Application.Services
{
    public class GameService : IGameServices
    {
        public readonly IUnitOfWork _uof;
        public readonly IMapper _mapper;
        public GameService(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public int AddPoint(Player player, bool resultCompair)
        {

            if(resultCompair)
                return player.Score++;
            return player.Score+=0;
        }

        public int CompairCards(Card cardOnTable, Card cardOnDeck)
        {   //1-maior, 0-menor, 2-igual
            var cardTableValue = int.Parse(cardOnTable.Value);
            var cardDeckValue = int.Parse(cardOnDeck.Value);
            var result = 1;
            if (cardDeckValue > cardTableValue)
                result = 1;
            if (cardDeckValue < cardTableValue)
                result =0;
            if (cardDeckValue == cardTableValue)
                result = 2;
            return result;
        }

        public bool CompairChoose(Guess compairCards, Guess playerChoose)
        {
            if(compairCards==(Guess)2)
                return true;
            return compairCards.Equals(playerChoose);
        }

        public Player PlayerTurn(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}
