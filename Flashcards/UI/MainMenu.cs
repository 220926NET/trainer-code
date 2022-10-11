using Services;
using Microsoft.Data.SqlClient;

namespace UI;

public class MainMenu
{
    private FlashCardService _service;

    public MainMenu(FlashCardService service)
    {
        _service = service;
    }
    

    public void ReviewCards(List<FlashCard> cards)
    {
        if(cards?.Count > 0)
        {
            foreach(FlashCard card in cards) {
                Console.WriteLine(card.Question);
                Console.WriteLine("Press Enter to reveal answer");
                Console.ReadLine();
                Console.WriteLine(card.Answer);
                Console.WriteLine("Did you get it right? [y/N]");

                string input = Console.ReadLine()!.Trim().ToLower();
                
                if(input.Length > 0 && input[0] == 'y') _service.ChangeCorrectness(true, card);
                else _service.ChangeCorrectness(false, card);
            }
        }
    }

    public void AddCard()
    {
        while(true)
        {
            Console.WriteLine("Enter the question:");
            string question = Console.ReadLine();
            Console.WriteLine("Enter the Answer:");
            string answer = Console.ReadLine();

            try
            {
                FlashCard cardToAdd = new FlashCard(question, answer);
                _service.AddNewCard(cardToAdd);
                return;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public void Start()
    {
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
                    Console.WriteLine("Randomize? (y/N)");
                    string random = Console.ReadLine()!.Trim().ToLower();
                    Console.WriteLine("Show only the ones you didn't get correctly?");
                    string showOnlyIncorrect = Console.ReadLine()!.Trim().ToLower();
                    bool onlyIncorrect = showOnlyIncorrect == "y";
                    bool randomized = random == "y";

                    try
                    {
                        ReviewCards(_service.GetAllCards(randomized, onlyIncorrect));
                    }
                    catch(SqlException ex)
                    {
                        Console.WriteLine("Something went wrong while trying to access db...");
                        Console.WriteLine(ex.Message);
                    }

                    break;
                case "x":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("I don't understand your input");
                    break;
            }
        }

    }
}