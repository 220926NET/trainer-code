using Models;

namespace DataAccess;

public interface IFlashCardStorage
{
    List<FlashCard> GetAllCards();

    void CreateCard(FlashCard cardToCreate);

}