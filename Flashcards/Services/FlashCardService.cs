using Models;
using DataAccess;

namespace Services;
public class FlashCardService
{
    public void AddNewCard(FlashCard card)
    {
        new StaticStorage().CreateCard(card);
    }

    public List<FlashCard> GetAllCards()
    {
        return new StaticStorage().GetAllCards();
    }

    /// <summary>
    /// Returns all cards. If random order is true, returns them in random order
    /// </summary>
    /// <param name="randomOrder"></param>
    /// <returns>List of all flashcards</returns>
    public List<FlashCard> GetAllCards(bool randomOrder)
    {
        if(randomOrder)
        {
            return GetAllCards().OrderBy(a => new Random().Next()).ToList();
        }
        else
        {
            return GetAllCards();
        }
    }

    public List<FlashCard> GetAllCards(bool randomOrder, bool onlyIncorrect)
    {
        List<FlashCard> allCards = GetAllCards();
        if(onlyIncorrect) {
            allCards = allCards.Where(card => card.CorrectlyAnswered == false).ToList();
        }
        if(randomOrder) {
            allCards = allCards.OrderBy(a => new Random().Next()).ToList();
        }

        return allCards;
    }

    public void ChangeCorrectness(bool IsCorrect, FlashCard cardToUpdate)
    {
        cardToUpdate.CorrectlyAnswered = IsCorrect;
        // cardToUpdate.CorrectlyAnswered = IsCorrect;
        // new StaticStorage().UpdateCard(cardToUpdate);
    }
}
