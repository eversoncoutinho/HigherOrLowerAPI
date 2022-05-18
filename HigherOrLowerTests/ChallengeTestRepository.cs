using Application.Mappings;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Infra;
using Infra.Data;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HigherOrLowerTests
{
    public class ChallengeTestRepository
    {
        private IUnitOfWork repository;
        private IMapper mapper;

        public static DbContextOptions<HigherOrLowerDbContext> dbContextOptions { get; }

        static ChallengeTestRepository( )
        {
            dbContextOptions = new DbContextOptionsBuilder<HigherOrLowerDbContext>()
            .UseSqlServer(MyConectionString.connectionString)
            .Options;
        }

        public ChallengeTestRepository( )
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();

            var context = new HigherOrLowerDbContext(dbContextOptions);
            repository = new UnitOfWork(context);
        }

        [Fact]
        public void ChallengeRepository_Return_OkResult( )
        {

            //Arrange
            var card = new Card("12", (Nipe)3)
            {
                Id = 17
            };
            var service = new ChallengeServices(repository, mapper);
            repository.CardRepository.Delete(card);
            repository.Commit();
            //Act
            var data = service.GetChallenge(1);

            //Assert
            Assert.NotNull(data.Games[0].CardOnTable);

        }

    }
}