using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;

namespace Infra.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(HigherOrLowerDbContext context) : base(context)
        {
        }
    }
}
