using FlashcardsAPI.Controllers;
using FlashcardsAPI.Infrastcuture;
using FlashcardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FlashcardsUnitTests
{
    public class CardControllerTests : IDisposable
    {
        DbContextOptionsBuilder<FlashcardContext> optionsBuilder;
        FlashcardContext dbContext;
        CardsController cardsController;

        public CardControllerTests()
        {
            optionsBuilder = new DbContextOptionsBuilder<FlashcardContext>();
            optionsBuilder.UseInMemoryDatabase("UnitTestMemoryDB");
            dbContext = new FlashcardContext(optionsBuilder.Options);

            cardsController = new CardsController(dbContext);
        }
        public void Dispose()
        {
            optionsBuilder = null;
            foreach (var card in dbContext.Cards)
            {
                dbContext.Cards.Remove(card);
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            cardsController = null;
        }

        [Fact]
        public void GetCardItems_ReturnZeroItems_WhenDBIsEmpty()
        {
            //Act
            var result = cardsController.GetCards();

            //Assert
            Assert.Empty(result.Value);
        }

        [Fact]
        public void GetCardItems_ReturnCountOne_WhenDBHasOne()
        {
            //Arrange
            var card = new Card
            {
                CardFront = "Front",
                CardBack = "Back",
                CardDescription = "Description",
                DeckId = 23,
            };

            dbContext.Cards.Add(card);
            dbContext.SaveChanges();

            //Act
            var result = cardsController.GetCards();

            //Assert
            Assert.Single(result.Value);
        }

        [Fact]
        public void GetCardItems_ReturnCount_WhenDBHasMany()
        {
            //Arrange
            var card1 = new Card
            {
                CardFront = "Front",
                CardBack = "Back",
                CardDescription = "Description",
                DeckId = 23,
            };

            var card2 = new Card
            {
                CardFront = "Front1",
                CardBack = "Back1",
                CardDescription = "Description1",
                DeckId = 23,
            };

            var card3 = new Card
            {
                CardFront = "Front2",
                CardBack = "Back2",
                CardDescription = "Description2",
                DeckId = 23,
            };

            dbContext.Cards.Add(card1);
            dbContext.Cards.Add(card2);
            dbContext.Cards.Add(card3);
            dbContext.SaveChanges();

            //Act
            var result = cardsController.GetCards();

            //Assert
            Assert.Equal(3, result.Value.Count());
        }

        [Fact]
        public void GetCardItems_ReturnsCorrectType()
        {
            //Act
            var result = cardsController.GetCards();

            //Assert
            Assert.IsType<ActionResult<IEnumerable<Card>>>(result);
        }

        [Fact]
        public void GetSingleCardItem_ReturnsTypeNull_WhenIdInvalid()
        {
            //Arrange
            var card = new Card
            {
                Id = 5,
            };

            dbContext.Add(card);
            dbContext.SaveChanges();

            //Act
            var result = cardsController.GetCard(3);

            //Assert
            Assert.Null(result.Value);
        }

        [Fact]
        public void GetSingleCardItem_Returns404_WhenIdInvalid()
        {
            //Arrange
            var card = new Card
            {
                Id = 5,
            };

            dbContext.Add(card);
            dbContext.SaveChanges();

            //Act
            var result = cardsController.GetCard(3);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetSingleCardItem_ReturnsCorrectType_WhenIdValid()
        {
            //Arrange
            var card = new Card
            {
                Id = 5,                
            };

            dbContext.Add(card);
            dbContext.SaveChanges();

            //Act
            var result = cardsController.GetCard(5);

            //Assert
            Assert.IsType<ActionResult<Card>>(result);
        }

        [Fact]
        public void GetSingleCardItem_ReturnsCorrectResource_WhenIdValid()
        {
            //Arrange
            var card = new Card
            {
                CardFront = "cardFront",
                CardBack = "cardBack",
                Id = 5,
            };

            dbContext.Add(card);
            dbContext.SaveChanges();

            //Act
            var result = cardsController.GetCard(5);

            //Assert
            Assert.Equal("cardFront", result.Value.CardFront);
        }

        [Fact]
        public void PostCardItem_CollectionSizeIncrementsByOne_WhenObjectValid()
        {
            //Arrange
            var card = new Card
            {
                Id = 1,
                CardFront = "Front",
                CardBack = "Back",
                CardDescription = "Description",
                DeckId = 5,
            };

            var oldCount = dbContext.Cards.Count();

            //Act
            var result = cardsController.CreateCard(card);

            //Assert
            Assert.Equal(oldCount + 1, dbContext.Cards.Count());
        }

        [Fact]
        public void PostCardItem_Returns201Created_WhenObjectValid()
        {
            //Arrange
            var card = new Card
            {
                Id = 1,
                CardFront = "Front",
                CardBack = "Back",
                CardDescription = "Description",
                DeckId = 5,
            };           

            //Act
            var result = cardsController.CreateCard(card);

            //Assert
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

    }
}
