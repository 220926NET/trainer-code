using Xunit;
using Moq;
using System.Collections.Generic;
using Services;
using Models;
using DataAccess;
using Microsoft.Data.SqlClient;

public class FlashCardServiceTest {
    [Fact]
    public void AddNewCardShouldCallCorrectMethod()
    {
        //we're verifying the behavior of Flashcard Service's AddNewCard method
        //I want to make sure that this method, calls its repository dependency's CreateCard method 

        //Arrange, Act, Assert
        //Arrange (set up everything)
        //1. Our mocked dependency (mocked repository class)
        //2. Our service class with the mocked repository class
        //3. fake data
        var mockedRepository = new Mock<IFlashCardStorage>();
        FlashCard cardToAdd = new FlashCard{
            Question = "What is xunit",
            Answer = "xunit is a csharp testing framework"
        };
        //Lets assume successful addition of the card- we return the added card
        //When someone calls the createcard with our mocked data, return another mocked data
        mockedRepository.Setup(repo => repo.CreateCard(cardToAdd)).Returns(new FlashCard{
            Id = 1,
            Question = "What is xunit",
            Answer = "xunit is a csharp testing framework"
        });

        //set up our service class with the mocked dependency
        FlashCardService service = new FlashCardService(mockedRepository.Object);

        //Act
        //Call service's AddNewCard method
        service.AddNewCard(cardToAdd);

        //Assert
        //Verify that the mocked repo's Create Card has been called once
        mockedRepository.Verify(repo => repo.CreateCard(cardToAdd), Times.Once());
    }

    private SqlException MakeSqlException() {
        SqlException exception = null;
        try {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Database=GUARANTEED_TO_FAIL;Connection Timeout=1");
            conn.Open();
        } catch(SqlException ex) {
            exception = ex;
        }
        return exception;
    }

    [Fact]
    public void AddNewCardShouldHandleSQLException()
    {
        //This one, we'll test the exception handling of addNewCard method

        //Arrange, Act, Assert
        //Arrange (set up everything)
        //1. Our mocked dependency (mocked repository class)
        //2. Our service class with the mocked repository class
        //3. fake data
        var mockedRepository = new Mock<IFlashCardStorage>();
        FlashCard cardToAdd = new FlashCard{
            Question = "What is xunit",
            Answer = "xunit is a csharp testing framework"
        };
        //Lets assume successful addition of the card- we return the added card
        //When someone calls the createcard with our mocked data, return another mocked data
        mockedRepository.Setup(repo => repo.CreateCard(cardToAdd)).Throws(MakeSqlException());

        //set up our service class with the mocked dependency
        FlashCardService service = new FlashCardService(mockedRepository.Object);

        //Act
        //Assert
        //Verify that the mocked repo's Create Card has been called once
        Assert.Throws<SqlException>(() => service.AddNewCard(cardToAdd));
        mockedRepository.Verify(repo => repo.CreateCard(cardToAdd), Times.Once());
    }

    [Fact]
    public void GetAllCardsShouldBeAbleToReturnOnlyIncorrectCards()
    {
        //In this test, we'll set the randomOrder to false, but onlyIncorrect to true, and give the service a dataset that is mixed with correct and incorrect cards
        //I want to verify that the service only returns the cards that are marked incorrect

        var mockedRepository = new Mock<IFlashCardStorage>();
        List<FlashCard> fakedata = new List<FlashCard> {
            new FlashCard{
                Question = "What is 1",
                Answer = "xunit is a csharp testing framework",
                CorrectlyAnswered = false
            },
            new FlashCard{
                Question = "What is 2",
                Answer = "xunit is a csharp testing framework",
                CorrectlyAnswered = true
            },
            new FlashCard{
                Question = "What is 3",
                Answer = "xunit is a csharp testing framework",
                CorrectlyAnswered = false
            },
            new FlashCard{
                Question = "What is 4",
                Answer = "xunit is a csharp testing framework",
                CorrectlyAnswered = false
            },
            new FlashCard{
                Question = "What is 5",
                Answer = "xunit is a csharp testing framework",
                CorrectlyAnswered = true
            },
            new FlashCard{
                Question = "What is 6",
                Answer = "xunit is a csharp testing framework",
                CorrectlyAnswered = false
            },
            new FlashCard{
                Question = "What is 7",
                Answer = "xunit is a csharp testing framework",
                CorrectlyAnswered = false
            }
        };
        //Lets assume successful addition of the card- we return the added card
        //When someone calls the createcard with our mocked data, return another mocked data
        mockedRepository.Setup(repo => repo.GetAllCards()).Returns(fakedata);

        //set up our service class with the mocked dependency
        FlashCardService service = new FlashCardService(mockedRepository.Object);

        //Act (let's ask for only incorrect cards)
        List<FlashCard> filteredCards = service.GetAllCards(false, true);

        //Assert that our repo method has been called, and we are not getting any of the wasCorrect = true
        mockedRepository.Verify(repo => repo.GetAllCards(), Times.Once());
        Assert.Equal(5, filteredCards.Count);
    }
}