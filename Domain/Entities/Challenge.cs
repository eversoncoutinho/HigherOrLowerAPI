using System.Collections.Generic;

namespace Domain.Entities
{
    public class Challenge
    {
        public Challenge(IList<string> players, IList<Game> games)
        {
            Players = players;
            Games = games;
        }
        
        public IList<string> Players { get; set; }
        public IList<Game> Games { get; set; }
    }
}
