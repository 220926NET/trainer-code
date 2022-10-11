using Models;

namespace DataAccess;

public interface IFlashCardStorage
{
    /// <summary>
    /// Returns all cards
    /// </summary>
    /// <returns>List of flashcards object</returns>
    List<FlashCard> GetAllCards();

    /// <summary>
    /// inserts a new card in the db
    /// </summary>
    /// <param name="cardToCreate">a card object to persist to db, id is optional, but question and answer is not</param>
    void CreateCard(FlashCard cardToCreate);

    /// <summary>
    /// Updates card with new question, answer, id, and wasCorrect
    /// </summary>
    /// <param name="cardToUpdate">Flashcard object to update, All properties are mandatory</param>
    /// <returns>the flashcard object that has been updated</returns>
    FlashCard UpdateCard(FlashCard cardToUpdate);

}