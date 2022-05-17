using Application.Interfaces;
using AutoMapper;
using Domain.Domain;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int AddPoint(int platerId, bool resultCompair)
        {
            //var player = new Player();
            
            //if (resultCompair)
            //{

            //}

            throw new NotImplementedException();
        }

        public string CompairCards(Card cardOnTable, Card cardOnDeck)
        {
            var cardTableValue = int.Parse(cardOnTable.Value);
            var cardDeckValue = int.Parse(cardOnDeck.Value);
            var result = "maior";
            if (cardDeckValue < cardTableValue)
                result = "igual";
            if (cardDeckValue< cardTableValue)
                result ="menor";
            return result;
        }

        public bool CompairChoose(string compairCards, string playerChoose)
        {
            return compairCards.Equals(playerChoose);
        }
    }
}
