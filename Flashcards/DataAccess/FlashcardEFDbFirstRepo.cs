using Models;
using DataAccess.Entities;

namespace DataAccess;

public class FlashcardEFDbFirstRepo : IFlashCardStorage
{
    private readonly FlashcardsDBContext _context;
    public FlashcardEFDbFirstRepo(FlashcardsDBContext context)
    {
        _context = context;
    }
    public Models.FlashCard CreateCard(Models.FlashCard cardToCreate)
    {
        DataAccess.Entities.FlashCard newCard = new Entities.FlashCard {
            Question = cardToCreate.Question,
            Answer = cardToCreate.Answer,
            WasCorrect = cardToCreate.CorrectlyAnswered
        };

        _context.Add(newCard);
        _context.SaveChanges();

        cardToCreate.Id = newCard.Id;

        return cardToCreate;
    }

    public List<Models.FlashCard> GetAllCards()
    {
        return _context.FlashCards.Select(c => new Models.FlashCard {
            Id = c.Id,
            Question = c.Question,
            Answer = c.Answer,
            CorrectlyAnswered = (bool) c.WasCorrect
        }).ToList();
    }

    public Models.FlashCard UpdateCard(Models.FlashCard cardToUpdate)
    {
        DataAccess.Entities.FlashCard updateCard = new Entities.FlashCard {
            Id = cardToUpdate.Id,
            Question = cardToUpdate.Question,
            Answer = cardToUpdate.Answer,
            WasCorrect = cardToUpdate.CorrectlyAnswered
        };

        _context.Update(updateCard);
        _context.SaveChanges();

        return cardToUpdate;
    }
}