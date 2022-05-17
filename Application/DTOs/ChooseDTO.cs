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

        public ChooseDTO(Guess guess, int challengeId)
        {
            Guess = guess;
            ChallengeId = challengeId;
        }
        public Guess Guess { get; set; }
        public int ChallengeId { get; set; }
    }
}
