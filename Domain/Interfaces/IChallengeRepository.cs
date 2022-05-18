using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IChallengeRepository : IRepository<Challenge>
    {
        Challenge GetChallenge(int id);
        Task<Challenge> GetChallengeAsync(int id);

    }
}
