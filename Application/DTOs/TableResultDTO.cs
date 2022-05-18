using Domain.Entities;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class TableResultDTO
    {
        public int ChallengeId { get; set; }
        public Card CardOntable { get; set; }
        public Card CardOnDeck { get; set; }
        public bool Result { get; set; }
        public string PlayerTurn { get; set; }
        public List<Player> Players { get; set; }
    }
}
