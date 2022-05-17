using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ChooseDTO
    {
        public ChooseDTO(){}

        public ChooseDTO(Guess guess, int challengeId, Player player = null)
        {
            Guess = guess;
            ChallengeId = challengeId;
            Player = player;
        }
        public Guess Guess { get; set; }
        public Player Player { get; set; }
        public int ChallengeId { get; set; }
    }
}
