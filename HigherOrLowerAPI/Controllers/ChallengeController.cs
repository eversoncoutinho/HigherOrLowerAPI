using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


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
                //deck = _iDeckServices.RemoveCardDeck(deck,cardOnTable);

                var players = new List<Player>();

                //TO DO - Create Player
                players.Add(new Player { Name = "Everson", Score = 1 });
                players.Add(new Player { Name = "Maria", Score = 1 });
                players.Add(new Player { Name = "Pedro", Score = 1 });

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
        
        public ActionResult<Challenge> yourTurn([FromBody] ChooseDTO chooseDTO)
        {
            //Open the current Challege
            var lastTurn = _uof.ChallengeRepository.GetChallenge(chooseDTO.ChallengeId);
            
            //Receber escolha do jogador (maior ou menor)

            var playerChoose = chooseDTO.Guess;

            //Deck
            //Escolher carta do deck
            var GetcardOnDeck = _iDeckServices.ChooseCard(lastTurn.Deck);
            var newDeck = _iDeckServices.RemoveCardDeck(lastTurn.Deck,GetcardOnDeck);
            _uof.DeckRepository.Update(newDeck);

            var cardOnTable = lastTurn.Games[lastTurn.Games.Count-1].CardOnTable;

            var compairCard = _gameServices.CompairCards(cardOnTable, GetcardOnDeck);
            var result = _gameServices.CompairChoose(compairCard, playerChoose);
            //Comparar com a carta da mesa
            //analisar se está certo ou errado
            //se acerto acrescentar 1 ao escore do jogador  
            //retirar a carta escolhida
            //update deck
            var game = new Game()
            {
                CardOnTable = GetcardOnDeck,
                Deck = newDeck,
                Guess = playerChoose,
                Result = false,

            };
           lastTurn.Games.Add(game);
           //var newTurn = new Challenge(chooseDTO.Player, lastTurn, newDeck);
            //_uof.ChallengeRepository.Update(newTurn);
            //_uof.Commit();

            return lastTurn;
        }

        [HttpGet("{id}")]
        public ActionResult<Challenge> Table(int id)
        {
            var lastTurn = _uof.ChallengeRepository.GetChallenge(id);
            
            return lastTurn;
        }


    } 
}
