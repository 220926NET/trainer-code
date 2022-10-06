using Models;
using DataAccess;

namespace Services;
public class FlashCardService
{
    public void AddNewCard(FlashCard card)
    {
        new StaticStorage().CreateCard(card);
    }

    /// <summary>
    /// Returns all cards based on given criteria
    /// </summary>
    /// <param name="randomOrder">returns cards in random order</param>
    /// <param name="onlyIncorrect">returns only cards that the user hasn't gotten correctly </param>
    /// <returns></returns>
    public List<FlashCard> GetAllCards(bool randomOrder, bool onlyIncorrect)
    {
        List<FlashCard> allCards = new StaticStorage().GetAllCards();
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
    }
}
