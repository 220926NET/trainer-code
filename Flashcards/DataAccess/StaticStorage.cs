using Models;

namespace DataAccess;

//Repository Pattern/DAO (Data access object)
public class StaticStorage : IFlashCardStorage
{
    private static List<FlashCard> allCards = new List<FlashCard> {
        new FlashCard {
            Id = 1,
            Question = "What is OOP",
            Answer = "Object Oriented Programming"
        },
        new FlashCard {
            Id = 2,
            Question = "4 Pillars of OOP",
            Answer = "Abstraction, Encapsulation, Polymorphism, Inheritance"
        },
        new FlashCard {
            Id = 3,
            Question = "What is git",
            Answer = "a version control system"
        },
        new FlashCard {
            Id = 4,
            Question = "What is abstraction",
            Answer = "a process of hiding implementation details and showing only the functionality to the user"
        },
        new FlashCard {
            Id = 5,
            Question = "What is Encapsulation",
            Answer = "1. Data Wrapping: Bundling related data and behavior together \n2. Data Hiding: controlling access of data (getters/setters, access modifiers)"
        },
        new FlashCard {
            Id = 6,
            Question = "What is an interface",
            Answer = "it's a contract consisting of public methods"
        },
        new FlashCard {
            Id = 7,
            Question = "What is a constructor",
            Answer = "A specialized method used to instantiate an object, uses the new keyword"
        }
    };

    public List<FlashCard> GetAllCards()
    {
        return allCards;
    }

    public void CreateCard(FlashCard cardToCreate)
    {
        cardToCreate.Id = StaticStorage.allCards.Count + 1;
        allCards.Add(cardToCreate);
    }

    public List<FlashCard> GetCardByQuestion(string queryStr)
    {
        throw new NotImplementedException();
    }

    public List<FlashCard> GetCardByAnswer(string queryStr)
    {
        throw new NotImplementedException();
    }

    //This needs a unique identifier for card, and information to update the card
    public void UpdateCard(FlashCard cardToUpdate)
    {
        //a way to find which card we're trying to update
        //the information we want to update the card with
        // FlashCard? card = allCards.FirstOrDefault(card => card.Id == cardToUpdate.Id);

        // if(card != null) {
        //     card.Question = cardToUpdate.Question;
        //     card.Answer = cardToUpdate.Answer;
        //     card.CorrectlyAnswered = cardToUpdate.CorrectlyAnswered;
        // }
        throw new NotImplementedException();
    }

    public void DeleteCard(int id)
    {
        //we need something to find the card that we want to delete it by
        //and then removal mechanism
        throw new NotImplementedException();
    }
}
