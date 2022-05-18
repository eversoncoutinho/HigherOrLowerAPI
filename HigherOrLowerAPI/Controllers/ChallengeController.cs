using Application.DTOs;
using Application.Interfaces;
using Application.Services;
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
        private readonly IDeckServices _deckServices;
        private readonly IGameServices _gameServices;
        private readonly IChallengeServices _challengeServices;
        public ChallengeController(IUnitOfWork uof, 
            IDeckServices iDeckServices, 
            IGameServices gameServices, 
            IChallengeServices challengeServices)
        {
            _uof = uof;
            _deckServices = iDeckServices;
            _gameServices = gameServices;
            _challengeServices = challengeServices;
        }

        [HttpGet("Start")]
       
        public ActionResult<TableDTO> StartChallenge(string NumberPlayer)
        {
            try
            {
                var deck = _deckServices.CreateDeck();
                var cardOnTable = _deckServices.ChooseCard(deck);

                var players = new List<Player>();

                //TO DO - Create Player
                players.Add(new Player { Name = "Everson", Score = 0 });
                players.Add(new Player { Name = "Maria", Score = 0 });

                var playerTurn = players [0];

                var gameStart = new Game(deck, cardOnTable, playerTurn);

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
                    CardOntable = _deckServices.ChooseCard(deck.Id),
                    PlayerTurn = playerTurn.Name,
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
        public IActionResult yourTurn([FromBody] GuessDTO guessDTO)


//        public ActionResult<TableResultDTO> yourTurn([FromBody] GuessDTO guessDTO)
        {
            //Open the current Challege
            
            var lastTurn = _uof.ChallengeRepository.GetChallenge(guessDTO.ChallengeId);

            var indexLastGame = lastTurn.Games.Count - 1;

            //Player
            var playerList = _uof.PlayerRepository.GetPlayerChallenge(guessDTO.ChallengeId);
            
            var lastPlayer = _uof.GameRepository.GetLastPlayer(lastTurn);
            var turnPlayer = playerList.FirstOrDefault(n=>n.Name==guessDTO.PlayerTurn);
            
 
            //Index to verify if is the last of Player
            var lastPlayerIndex = playerList.IndexOf(lastPlayer);
            var turnPlayerIndex = playerList.IndexOf(turnPlayer);

            var nextPlayer = new Player(); 
            if (turnPlayerIndex!=playerList.Count-1)
            {
                nextPlayer=playerList[turnPlayerIndex+1];
            }
            else {
                nextPlayer = playerList [0];
            }
            var lastDeck = lastTurn.Deck;
            
            
            //Receber escolha do jogador (maior ou menor)

            var playerChoose = guessDTO.Guess;
            

            //Deck
            //Escolher carta do deck
            var GetcardOnDeck = _deckServices.ChooseCard(lastDeck);
            if (GetcardOnDeck.Value==null)
            {
                return NotFound($"Fim do jogo");
            }

            //Get Card On TAble
            var cardOnTable = lastTurn.Games[indexLastGame].CardOnTable;
            if (cardOnTable == null)
                cardOnTable = _deckServices.ChooseCard(lastDeck);
            
            //Compair Cards
            var compairCard = _gameServices.CompairCards(cardOnTable, GetcardOnDeck);

            //guess result - true or false
            var result = _gameServices.CompairChoose((Guess)compairCard, guessDTO.Guess);

            //jogar fora a carta que estava na mesa
           _deckServices.RemoveCardDeck(cardOnTable);

            //if true Add 1 to score player  
            var Score = _gameServices.AddPoint(turnPlayer, result);
            

            var game = new Game()
            {
                CardOnTable = GetcardOnDeck,
                Deck = lastDeck,
                Guess = playerChoose,
                Result = result,
                Player= turnPlayer
            };
           lastTurn.Games.Add(game);
            
            
            var tableDTO = new TableResultDTO()
            {
                ChallengeId = lastTurn.Id,
                CardOntable = cardOnTable,
                CardOnDeck = GetcardOnDeck,
                PlayerTurn = turnPlayer.Name,
                NextPlayer=nextPlayer.Name,
                Players = lastTurn.Players,
                Result = result,
                
            };

            _deckServices.RemoveCardDeck(cardOnTable);
            
            _uof.DeckRepository.Update(lastDeck);

            //Commit All
            _uof.CommitAsync();

            
            if (turnPlayerIndex==playerList.Count-1)
            {

                var score = _challengeServices.Score(tableDTO.Players);
               
                return Ok(score);
            }

            return Ok(tableDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<Challenge> Game(int id)
        {

            var lastTurn = _uof.ChallengeRepository.GetChallenge(id);
            
            return lastTurn;
        }


    } 
}
