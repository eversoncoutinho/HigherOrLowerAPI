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
        public ChallengeController(IUnitOfWork uof, IDeckService iDeckServices)
        {
            _uof = uof;
            _iDeckServices = iDeckServices;

        }

        [HttpGet("Start")]
       
        public ActionResult<TableDTO> StartChallenge(string NumberPlayer)
        {
            try
            {
                var deck = _iDeckServices.CreateDeck();
                var cardOnTable = _iDeckServices.ChooseCard(deck);
                deck = _iDeckServices.RemoveCardDeck(deck,cardOnTable);

                var players = new List<Player>();

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


        [HttpGet("{id}")]
        public ActionResult<Challenge> Table(int id)
        {
            var lastTurn = _uof.ChallengeRepository.GetChallenge(id);
            
            return lastTurn;
        }



        //[HttpGet("{id}")]
        
        //public IActionResult Post([FromBody] ChooseDTO chooseDto)
        // {

        //     var challege = _uof.ChallengeRepository.GetChallengeAsync(chooseDto.ChallengeId);
        //     var ChooseCard = _iDeckServices.ChooseCard(challege.Result.Deck);
        //     //var cardOnTable = 

        // }
    } 
}
