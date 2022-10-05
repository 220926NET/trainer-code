using Models;

namespace DataAccess;

//Repository Pattern/DAO (Data access object)
public class StaticStorage : IFlashCardStorage
{
    private static List<FlashCard> allCards = new List<FlashCard> {
        new FlashCard {
            Question = "What is OOP",
            Answer = "Object Oriented Programming"
        },
        new FlashCard {
            Question = "4 Pillars of OOP",
            Answer = "Abstraction, Encapsulation, Polymorphism, Inheritance"
        },
        new FlashCard {
            Question = "What is git",
            Answer = "a version control system"
        }
    };

    public List<FlashCard> GetAllCards()
    {
        return allCards;
    }

    public void CreateCard(FlashCard cardToCreate)
    {
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
    public void UpdateCard(int id, FlashCard cardToUpdate)
    {
        //a way to find which card we're trying to update
        //the information we want to update the card with
        throw new NotImplementedException();
    }

    public void DeleteCard(int id)
    {
        //we need something to find the card that we want to delete it by
        //and then removal mechanism
    }
}
