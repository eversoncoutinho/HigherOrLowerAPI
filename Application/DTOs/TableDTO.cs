using Domain.Entities;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class TableDTO
    {
        public int ChallengeId { get; set; }
        public Card CardOntable { get; set; }
        public string PlayerTurn { get; set; }
        public string NextPlayer { get; set; }
        public List<Player> Players { get; set; }
    }
}
