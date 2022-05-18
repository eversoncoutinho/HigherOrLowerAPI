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


        public ScoreDTO(List<Player> players)
        {
            Players = players;
        }
        public ScoreDTO(List<Player> players, int gameNumber)
        {

            Players = players;
            GameNumber = gameNumber;
        }
        public int GameNumber { get; set; } 
        public List<Player> Players { get; set; }
        
    }
}
