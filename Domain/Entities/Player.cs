using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Player:Entity
    {
        public Player(){}

        public Player(string name, int score=0)
        {
            Name = name;
            Score = score;
        }
        public string Name { get; set; }
        public int Score { get; set; }

    }
}
