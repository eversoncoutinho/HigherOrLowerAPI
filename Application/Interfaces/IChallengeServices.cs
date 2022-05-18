using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IChallengeServices
    {
        Challenge GetChallenge(int challengeId);
        ScoreDTO Score(List<Player> players);
    }
}
