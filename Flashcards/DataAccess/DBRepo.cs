using Models;
using Microsoft.Data.SqlClient;

namespace DataAccess;

/*
ADO.NET : Which is a collection of classes and tools to interact with variety of data sources in uniform fashion
*/
public class DBRepo : IFlashCardStorage
{
    public void CreateCard(FlashCard cardToCreate)
    {
        throw new NotImplementedException();
    }

    public List<FlashCard> GetAllCards()
    {   
        List<FlashCard> cards = new();
        /*
        Connecting and interacting with DB..
        1. Connect to the db
            - Tell the program where to go find the dbServer, and the credentials (provided via connectionstring)
            - Open the connection
        2. Assemble the query/Sql statements you're interested in running
        3. Execute those statements
        4. Get the result
        5. Process the result, so rest of the application can understand/consume it
        6. Close the connection
        7. Return the result to the caller
        */
        SqlConnection connection = new SqlConnection("Server=tcp:220926net.database.windows.net,1433;Initial Catalog=FlashcardsDB;Persist Security Info=False;User ID=flashcard-admin;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        connection.Open();

        SqlCommand command = new SqlCommand("SELECT * FROM FlashCards;", connection);

        SqlDataReader reader = command.ExecuteReader();
        
        if(reader.HasRows)
        {
            while(reader.Read()) 
            {
                int id = (int) reader["Id"];
                string q = (string) reader["Question"];
                string a = (string) reader["Answer"];
                bool wasCorrect = (bool) reader["WasCorrect"];

                FlashCard card = new FlashCard {
                    Id = id,
                    Question = q,
                    Answer = a,
                    CorrectlyAnswered = wasCorrect
                };

                cards.Add(card);
            }
        }

        connection.Close();

        return cards;
    }
}