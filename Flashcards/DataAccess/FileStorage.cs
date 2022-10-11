// using Models;
// using System.Text.Json;

// namespace DataAccess;

// public class FileStorage : IFlashCardStorage
// {
//     public FileStorage()
//     {
//         if(!File.Exists(FILE_PATH))
//         {   
//             FileStream fs = File.Create(FILE_PATH);
//             fs.Close();
//         }
//     }
//     private const string FILE_PATH = "../DataAccess/flashcards.json";
//     public void CreateCard(FlashCard cardToCreate)
//     {
//         List<FlashCard> allCards = GetAllCards();
//         cardToCreate.Id = allCards.Count + 1;

//         allCards.Add(cardToCreate);
//         string jsonString = "";
//         try
//         {
//             jsonString = JsonSerializer.Serialize(allCards);
//         }
//         catch(JsonException ex)
//         {
//             Console.WriteLine("Something went wrong");
//         }
//         File.WriteAllText(FILE_PATH, jsonString);
//     }

//     public List<FlashCard> GetAllCards()
//     {
//         string readText = File.ReadAllText(FILE_PATH);
//         //ternary, a shorthand for if/else statement
//         return readText.Length == 0 ? new List<FlashCard>() : JsonSerializer.Deserialize<List<FlashCard>>(readText);

//         // if(readText.Length == 0)
//         // {
//         //     return new List<FlashCard>();
//         // }
//         // else
//         // {
//         //     return JsonSerializer.Deserialize<List<FlashCard>>(readText);
//         // }
//     }

//     public FlashCard UpdateCard(FlashCard cardToUpdate)
//     {
//         throw new NotImplementedException();
//     }
// }