using Domain.Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DeckDTO
    {
        public DeckDTO( ) { }
        public DeckDTO(List<Card> cards)
        {
            Cards = cards;
        }
        public int Id { get; set; }

        public List<Card> Cards { get; set; }
    }
}
