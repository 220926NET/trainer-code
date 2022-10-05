using Models;
using DataAccess;

namespace Services;
public class FlashCardService
{
    public void AddNewCard(FlashCard card)
    {
        StaticStorage.CreateCard(card);
    }

    public List<FlashCard> GetAllCards()
    {
        return StaticStorage.GetAllCards();
    }
}
