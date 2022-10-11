/*
Flashcard app

MVP:
- user should be able to see a flashcard
- they should be able to see the question and the answer (flip the flashcard)

Other Features:
- Show the cards in random order (done)
- Let the users enter the definition (perhaps compare it to the answer on the flashcard)
- Ask the user how many flashcards they want to review at this time
- Get the current number of cards in the stack
- Being able to mark it if the user got it right or wrong
    - Users can review only the ones they got wrong
- Last time reviewed
    - and being able to review cards that I haven't reviewed in awhile
- Persistence (external storage)
- Index of cards
- Category of cards
- Being able to see answers then come up with question
- Final score
*/

using Services;
using DataAccess;
using UI;
using Microsoft.Data.SqlClient;

//Dependency Injection chain
SqlConnectionFactory factory = new SqlConnectionFactory();

FlashCardRepo repo = new FlashCardRepo(factory);

FlashCardService service = new FlashCardService(repo);

MainMenu menu = new MainMenu(service);

menu.Start();


// new MainMenu(new FlashCardService(new FlashCardRepo(new SqlConnectionFactory().GetConnection()))).Start();