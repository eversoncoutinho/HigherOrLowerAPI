using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HigherOrLowerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IDeckService _iDeckServices;
        private readonly IGameServices _gameServices;
        public ChallengeController(IUnitOfWork uof, IDeckService iDeckServices,IGameServices gameServices)
        {
            _uof = uof;
            _iDeckServices = iDeckServices;
            _gameServices = gameServices;
        }

        [HttpGet("Start")]
       
        public ActionResult<TableDTO> StartChallenge(string NumberPlayer)
        {
            try
            {
                var deck = _iDeckServices.CreateDeck();
                var cardOnTable = _iDeckServices.ChooseCard(deck);

                var players = new List<Player>();

                //TO DO - Create Player
                players.Add(new Player { Name = "Everson", Score = 1 });
                players.Add(new Player { Name = "Maria", Score = 1 });
                

                var gameStart = new Game(deck, cardOnTable);

                var gamesHistory = new List<Game>();
                gamesHistory.Add(gameStart);
                var challengeStart = new Challenge(players, gamesHistory, deck);

                _uof.ChallengeRepository.Add(challengeStart);
                _uof.DeckRepository.Add(deck);
                _uof.GameRepository.Add(gameStart);
                _uof.Commit();
                //var challenge = new Challenge(players, game);

                var tableDTO = new TableDTO()
                {
                    ChallengeId = challengeStart.Id,
                    CardOntable = _iDeckServices.ChooseCard(deck.Id),
                    PlayerTurn = "Everson",
                    Players = players,
                };
                return tableDTO;
           }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "I'm sorry. Server Error. Contact us to support");
            };

        }
        [HttpPost("YourTurn")]
        
        public IActionResult<TableResultDTO> yourTurn([FromBody] ChooseDTO chooseDTO)
        {
            //Open the current Challege
            
            var lastTurn = _uof.ChallengeRepository.GetChallenge(chooseDTO.ChallengeId);
            var index = lastTurn.Games.Count - 1;
            var sd = lastTurn.Games.ElementAtOrDefault(index);
            

            var deck = lastTurn.Deck;
            //Receber escolha do jogador (maior ou menor)

            var playerChoose = chooseDTO.Guess;

            //Deck
            //Escolher carta do deck
            var GetcardOnDeck = _iDeckServices.ChooseCard(deck);
            if (GetcardOnDeck.Value==null)
            {
                return NotFound($"Fim do jogo");
            }
            //var newDeck = _iDeckServices.RemoveCardDeck(deck,GetcardOnDeck);
            //_uof.DeckRepository.Update(newDeck);           

            var cardOnTable = lastTurn.Games[index].CardOnTable;
            if (cardOnTable == null)
                cardOnTable = _iDeckServices.ChooseCard(deck);
            //Comparar com a carta da mesa
            var compairCard = _gameServices.CompairCards(cardOnTable, GetcardOnDeck);

            //analisar se está certo ou errado
            var result = _gameServices.CompairChoose((Guess)compairCard, chooseDTO.Guess);


            //se acerto acrescentar 1 ao escore do jogador  
            //jogar fora a carta que estava na mesa
           _iDeckServices.RemoveCardDeck(cardOnTable);

            
            var game = new Game()
            {
                CardOnTable = GetcardOnDeck,
                Deck = deck,
                Guess = playerChoose,
                Result = result,

            };
           lastTurn.Games.Add(game);
            //var newTurn = new Challenge(chooseDTO.Player, lastTurn, newDeck);
            //_uof.ChallengeRepository.Update(newTurn);
            _uof.CommitAsync();

            var tableDTO = new TableResultDTO()
            {
                ChallengeId = lastTurn.Id,
                CardOntable = cardOnTable,
                CardOnDeck = GetcardOnDeck,
                PlayerTurn = "Everson",
                Players = lastTurn.Players,
                Result = result,
                
            };

            _iDeckServices.RemoveCardDeck(cardOnTable);
            //update deck
            _uof.DeckRepository.Update(deck);

            return tableDTO;
        }

        [HttpGet("{id}")]
        public ActionResult<Challenge> Table(int id)
        {
            var lastTurn = _uof.ChallengeRepository.GetChallenge(id);
            
            return lastTurn;
        }


    } 
}
