using Models;
using DataAccess;
using Microsoft.Data.SqlClient;

namespace Services;
public partial class FlashCardService
{
    private IFlashCardStorage _repo;
    public FlashCardService(IFlashCardStorage repo)
    {
        _repo = repo;
    }
    public FlashCard AddNewCard(FlashCard card)
    {
        return _repo.CreateCard(card);
    }

    /// <summary>
    /// Returns all cards based on given criteria
    /// </summary>
    /// <param name="randomOrder">returns cards in random order</param>
    /// <param name="onlyIncorrect">returns only cards that the user hasn't gotten correctly </param>
    /// <returns></returns>
    public List<FlashCard> GetAllCards(bool randomOrder, bool onlyIncorrect)
    {
        try
        {
            List<FlashCard> allCards = _repo.GetAllCards();
            if(onlyIncorrect) {
                allCards = allCards.Where(card => card.CorrectlyAnswered == false).ToList();
            }
            if(randomOrder) {
                allCards = allCards.OrderBy(a => new Random().Next()).ToList();
            }
            return allCards;
        }
        catch(SqlException)
        {
            throw;
        }
    }

    public void UpdateCard(FlashCard cardToUpdate)
    {
        _repo.UpdateCard(cardToUpdate);
    }
}
