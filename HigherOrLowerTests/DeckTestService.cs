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
using Xunit;

namespace HigherOrLowerTests
{
    public class DeckTestService
    {
        private IUnitOfWork repository;
        private IMapper mapper;

        public static DbContextOptions<HigherOrLowerDbContext> dbContextOptions { get; }

        static DeckTestService( )
        {
            dbContextOptions = new DbContextOptionsBuilder<HigherOrLowerDbContext>()
            .UseSqlServer(MyConectionString.connectionString)
            .Options;
        }

        public DeckTestService( )
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
        public void GetCardsService_Return_OkResult( )
        {

            //Arrange            
            var service = new DeckServices(repository, mapper);

            //Act
            var data = service.GetDeckAsync(2).Result;

            //Assert
            Assert.IsType<Deck>(data);

        }

        [Fact]
        public void CreateDeckService_Return_OkResult( )
        {
            //Arrange            
            var service = new DeckServices(repository, mapper);

            //Act
            var data = service.CreateDeck();

            //Assert
            Assert.IsType<Deck>(data);
            Assert.NotEqual(0,data.Id);
        }
        [Fact]
        public void ChooseCardFromDeck_Return_OkResult( )
        {
        //Arrange            
        var service = new DeckServices(repository, mapper);

        //Act
        var data = service.ChooseCard(3);

            var show = data.Value;
        //Assert
         Assert.IsType<Card>(data);
            Assert.IsNotType<int>(data.Value);
        }
        [Fact]
        public void DeleteCardFromDeck_Return_OkResult( )
        {
            //Arrange
            var service = new DeckServices(repository, mapper);
            var deck=new Deck();
            var card = new Card("2",(Nipe)1);
            var deckId = 3;
            var data = service.GetDeckAsync(deckId).Result;

            //Act
            var result = service.DeleteCard(deckId, card).Result;

            //Assert
            Assert.IsType<Deck>(result);
            Assert.Equal(49,result.Cards.Count);

        }

    }
}