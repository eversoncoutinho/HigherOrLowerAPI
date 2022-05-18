using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class WinnerDTO
    {
        public WinnerDTO( ) { }
        public WinnerDTO(int challengeId, List<Player> winners)
        {
            Challenge = challengeId;
            Winners = winners;
        }
        public int Challenge { get; set; }

        public List<Player> Winners { get; set; }
    }
}
