using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        private readonly HigherOrLowerDbContext _context;
        public GameRepository(HigherOrLowerDbContext context) : base(context)
        {
            _context = context;
        }

        public Player GetLastPlayer(Challenge challenge)
        {
            var c = challenge.Games.Count()-1;
            var LastGame = challenge.Games.ToList() [c];
            var player = LastGame.TurnPlayer.Name;
            var score = LastGame.TurnPlayer.Score;

//            var p = challenge.Games.

            var play = new Player(player, score) { Id=LastGame.TurnPlayer.Id};
            return play;
        }

        //public Player GetLastPlayer(int challengeId)
        //{
        //    var player = _context.Games.Where();
        //    retun player;
        //}
    }
}
