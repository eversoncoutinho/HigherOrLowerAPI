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
    public class ChallengeService: IChallengeServices
    {
        public readonly IUnitOfWork _uof;
        public readonly IMapper _mapper;
        public ChallengeService(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        public Challenge GetChallenge(int challengeId)
        {
            var result = _uof.ChallengeRepository.GetChallenge(challengeId);
          
             return result;
        }
    }
}
