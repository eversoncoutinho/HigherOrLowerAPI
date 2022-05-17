using Domain.Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TableDTO
    {
        public int ChallengeId { get; set; }
        public Card CardOntable { get; set; }
        public string PlayerTurn { get; set; }
        public List<Player> Players { get; set; }
    }
}
