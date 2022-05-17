﻿using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


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
        public TableDTO StartChallenge(string NumberPlayer)
        {
            
            var deck = _iDeckServices.CreateDeck();
            var cardOnTable = _iDeckServices.ChooseCard(deck);           
            
            var players = new List<Player>();
            
            players.Add(new Player { Name = "Everson", Score = 1});
            players.Add(new Player { Name = "Maria", Score = 1 });
            players.Add(new Player { Name = "Pedro", Score = 1 });

            var gameStart = new Game(deck, cardOnTable);
            
            var gamesHistory = new List<Game>();
            gamesHistory.Add(gameStart);
            var challengeStart = new Challenge(players, gamesHistory,deck);

            _uof.ChallengeRepository.Add(challengeStart);
            _uof.GameRepository.Add(gameStart);
            _uof.Commit();
            //var challenge = new Challenge(players, game);
            
            var tableDTO = new TableDTO() 
            { 
                            CardOntable=_iDeckServices.ChooseCard(deck.Id),
                            PlayerTurn = "Everson",
                            Players= players,
            };
            return tableDTO;
        }
        
       //[HttpPost("Jogada")]
       //[ValidateAntiForgeryToken]
       // public IActionResult Post([FromBody] ChooseDTO chooseDto)
       // {
            
       //     var challege = _uof.ChallengeRepository.GetChallengeAsync(chooseDto.ChallengeId);
       //     var ChooseCard = _iDeckServices.ChooseCard(challege.Result.Deck);
       //     //var cardOnTable = 

       // }
    } 
}