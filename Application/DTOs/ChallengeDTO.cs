using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ChallengeDTO
    {
        public ChallengeDTO(string state, int games, List<Player> players, string winner)
        {
            State = state;
            Games = games;
            Players = players;
            Winner = winner;
        }

        public string State { get; set; }
        public string Winner { get; set; }
        public int Games { get; set; }
        public List<Player> Players { get; set; } 
        
    }
}
