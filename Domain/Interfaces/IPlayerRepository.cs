using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPlayerRepository: IRepository<Player>
    {
        List<Player> GetPlayerChallenge(int challegeId);
    }
}
