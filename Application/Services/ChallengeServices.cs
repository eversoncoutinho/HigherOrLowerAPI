using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ChallengeServices: IChallengeServices
    {
        public readonly IUnitOfWork _uof;
        public readonly IMapper _mapper;
        public ChallengeServices(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public Challenge GetChallenge(int challengeId)
        {
            var result = _uof.ChallengeRepository.GetChallenge(challengeId);
          
             return result;
        }

        public ScoreDTO Score(List<Player> players)
        {
            
            return new ScoreDTO(players);
        }
    }
}
