using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ScoreDTO
    {
        
        public ScoreDTO(){}

        public ScoreDTO(int score, Player player)
        {
            Score = score;
            Player = player;
        }
        public int Score { get; set; }
        public Player Player { get; set; }
        
    }
}
