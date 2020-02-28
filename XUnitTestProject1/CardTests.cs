using FlashcardsAPI.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace FlashcardsUnitTests
{
    public class CardTests : IDisposable
    {

        Card testCard;

        public CardTests()
        {
            testCard = new Card()
            {
                CardFront = "Front",
                CardBack = "Back",
                CardDescription = "Description",
            };
        }

        public void Dispose()
        {
            testCard = null;
        }

        [Fact]
        public void CanChangeCardFront()
        {
            //Arrange            
            //No need for arrange, since setup is done in constructor and instance is being set null for each and every test

            //Act
            testCard.CardFront = "New Front";

            //Assert
            Assert.Equal("New Front", testCard.CardFront);
        }        
    }
}
