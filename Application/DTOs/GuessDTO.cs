using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GuessDTO
    {
        public GuessDTO(){}

        public GuessDTO(Guess guess, int challengeId, string playerTurn)
        {
            Guess = guess;
            ChallengeId = challengeId;
            PlayerTurn = playerTurn;
        }
        public Guess Guess { get; set; }
        public string PlayerTurn { get; set; }
        public int ChallengeId { get; set; }
    }
}
