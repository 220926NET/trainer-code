/*
Flashcard app

MVP:
- user should be able to see a flashcard
- they should be able to see the question and the answer (flip the flashcard)

Other Features:
- Show the cards in random order
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

using Models;
using Services;

while(true)
{
    Console.WriteLine("Welcome to Flashcard App");
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("[1] Add new flashcard");
    Console.WriteLine("[2] Review all flashcard");
    Console.WriteLine("[x] to exit");
    string menuChoice = Console.ReadLine();

    switch(menuChoice)
    {
        case "1":
            AddCard();
            break;
        case "2":
            ReviewCards(new FlashCardService().GetAllCards());
            break;
        case "x":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("I don't understand your input");
            break;
    }
}


static void ReviewCards(List<FlashCard> cards)
{
    foreach(FlashCard card in cards) {
        Console.WriteLine(card.Question);
        Console.WriteLine("Press Enter to reveal answer");
        Console.ReadLine();
        Console.WriteLine(card.Answer);
        Console.WriteLine("Press Enter to continue");
        Console.ReadLine();
    }
}

static void AddCard()
{
    while(true)
    {
        Console.WriteLine("Enter the question:");
        string question = Console.ReadLine();
        Console.WriteLine("Enter answer: ");
        string answer = Console.ReadLine();

        try
        {
            FlashCard cardToAdd = new FlashCard(question, answer);
            new FlashCardService().AddNewCard(cardToAdd);
            return;
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}