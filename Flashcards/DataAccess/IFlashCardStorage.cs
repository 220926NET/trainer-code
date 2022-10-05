using Models;

namespace DataAccess;

public interface IFlashCardStorage
{
    List<FlashCard> GetAllCards();

    void CreateCard(FlashCard cardToCreate);

    List<FlashCard> GetCardByQuestion(string queryStr);

    List<FlashCard> GetCardByAnswer(string queryStr);

}