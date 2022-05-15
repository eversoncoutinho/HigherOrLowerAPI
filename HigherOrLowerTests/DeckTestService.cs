using Application.Services;
using Domain.Entities;
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

        public static DbContextOptions<HigherOrLowerDbContext> dbContextOptions { get; }

        static DeckTestService( )
        {
            dbContextOptions = new DbContextOptionsBuilder<HigherOrLowerDbContext>()
            .UseSqlServer(MyConectionString.connectionString)
            .Options;
        }

        //dências injetadas lá no controller

        public DeckTestService( )
        {
            var context = new HigherOrLowerDbContext(dbContextOptions);
            repository = new UnitOfWork(context);
        }

        [Fact]
        public void GetCardsService_Return_OkResult( )
        {

            //Arrange            
            var service = new DeckService(repository);

            //Act
            var data = service.GetCardsAsync().Result;

            //Assert
            Assert.IsType<List<Card>>(data);
            
        }
    
        [Fact]
        public void CreateDeckService_Return_OkResult( )
        {
            //Arrange            
            var service = new DeckService(repository);

            //Act
            var data = service.CreateDeckAsync().Result;

            //Assert
            Assert.IsType<Deck>(data);

        }
    }
}
