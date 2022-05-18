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
    public class GameTestService
    {
        private IUnitOfWork repository;
        private IMapper mapper;

        public static DbContextOptions<HigherOrLowerDbContext> dbContextOptions { get; }

        static GameTestService( )
        {
            dbContextOptions = new DbContextOptionsBuilder<HigherOrLowerDbContext>()
            .UseSqlServer(MyConectionString.connectionString)
            .Options;
        }

        public GameTestService( )
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
        public void CompairCardsService_Return_OkResult( )
        {

            //Arrange            
            var deckId = 1;
            var service = new GameServices(repository, mapper);
            var serviceDeck = new DeckServices(repository, mapper);
            
            
           // var deck = repository.DeckRepository.GetDeckAsync(deckId);//get deck

            var cardOnTable = new Card() { Value = "14", Nipe = 0 };
            var cardOnDeck = serviceDeck.ChooseCard(deckId);
            
            //Act
            var data = service.CompairCards(cardOnTable,cardOnDeck);

            //Assert
            Assert.IsType<string>(data);
            
            Assert.Equal(0,data);

        }

        [Fact]
        public void CompairChooseService_Return_OkResult( )
        {
            //Arrange
            var deckId = 1;
            var service = new GameServices(repository, mapper);
            var serviceDeck = new DeckServices(repository, mapper);

            var cardOntable = new Card() { Value = "11", Nipe = 0 };
            var cardInDeck = serviceDeck.ChooseCard(deckId);
            var compairCards = service.CompairCards(cardOntable,cardInDeck);

            var playerChoose =(Guess)0;

            //Act
            var data = service.CompairChoose((Guess)compairCards, playerChoose);

            //Assert
            Assert.IsType<bool>(data);
            Assert.True(data);

        }
        [Fact]
        public void AddPointService_Return_OkResult( )
        {
            //Arrange
            var service = new GameServices(repository, mapper);
            var player = repository.PlayerRepository.GetById(n=>n.Id==23);


            //Act
            var data = service.AddPoint(player, true);
            repository.Commit();
            //Assert
            Assert.IsType<int>(data);
            Assert.Equal(5, player.Score);

        }


    }

}
