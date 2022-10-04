using Xunit;
using System;
using Models;

namespace Tests;

public class FlashCardTests
{
    [Fact]
    public void FlashCardConstructorShouldCreate()
    {
        //Arrange, Act, Assert (AAA)
        //Arrange is our set up

        //Act is where we actually perform the behavior we wish to test

        //Assert is where we verify that the behavior matches what we expect

        //Arrange
        string testQ = "test question";
        string testA = "test answer";

        //Act
        FlashCard card = new FlashCard(testQ, testA);

        //Assert
        Assert.NotNull(card);
        Assert.Equal(card.Question, testQ);
        Assert.Equal(card.Answer, testA);
    }

    [Fact]
    public void QuestionShouldSetValidData()
    {
        //Arrange, Act, Assert
        //Arrange
        string validData = "test question";
        FlashCard card = new FlashCard();

        //Act
        card.Question = validData;

        //Assert
        Assert.Equal(card.Question, validData);
        Assert.NotNull(card);
    }

    [Theory]
    [InlineData("")]
    [InlineData("            ")]
    [InlineData(null)]
    public void QuestionShouldNotSetInvalidData(string input)
    {
        //Arrange
        FlashCard card = new FlashCard();

        //Act & Assert
        Assert.Throws<ArgumentException>(() => card.Question = input);
    }
}