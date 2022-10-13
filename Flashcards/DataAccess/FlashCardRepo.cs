using Models;
using Microsoft.Data.SqlClient;

namespace DataAccess;

/*
ADO.NET : Which is a collection of classes and tools to interact with variety of data sources in uniform fashion
*/
public class FlashCardRepo : IFlashCardStorage
{
    private SqlConnectionFactory _factory;


    public FlashCardRepo(SqlConnectionFactory factory) {
        _factory = factory;
    }
    public FlashCard CreateCard(FlashCard cardToCreate)
    {
        /*
        Connecting and interacting with DB..
        1. Connect to the db
            - Tell the program where to go find the dbServer, and the credentials (provided via connectionstring)
            - Open the connection
        2. Assemble the query/Sql statements you're interested in executing
        3. Execute those statements
        4. Close the connection
        5. Return the result to the caller
        */

        try
        {
            using SqlConnection conn = _factory.GetConnection();
            conn.Open();

            //very dangerous code, do not do this
            // SqlCommand cmd = new SqlCommand($"INSERT INTO FlashCards (Question, Answer) VALUES ('{cardToCreate.Question}', '{cardToCreate.Answer}')", connection);

            //preventing against sql injection
            using SqlCommand cmd = new SqlCommand("INSERT INTO FlashCards (Question, Answer) OUTPUT INSERTED.Id VALUES (@question, @answer);", conn);
            cmd.Parameters.AddWithValue("@question", cardToCreate.Question);
            cmd.Parameters.AddWithValue("@answer", cardToCreate.Answer);

            int insertedId = (int) cmd.ExecuteScalar();
            cardToCreate.Id = insertedId;
        }
        catch(SqlException)
        {
            throw;
        }

        return cardToCreate;

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

        try
        {
            using SqlConnection conn = _factory.GetConnection();
            conn.Open();

            using SqlCommand command = new SqlCommand("SELECT * FROM FlashCards;", conn);

            using SqlDataReader reader = command.ExecuteReader();
            
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


        }
        catch(SqlException ex)
        {
            //great opportunity to log to logger
            throw;
        }
        finally
        {
            conn.Close();
        }

        return cards;
    }

    public FlashCard UpdateCard(FlashCard cardToUpdate)
    {
        FlashCard card = new();
        try
        {
            using SqlConnection conn = _factory.GetConnection();

            //open the connection
            conn.Open();

            //assemble the sql statement
            using SqlCommand cmd = new SqlCommand("UPDATE FlashCards SET WasCorrect = @isCorrect, Question = @q, Answer = @a WHERE Id = @id; SELECT * FROM FlashCards WHERE Id = @id", conn);

            //add all parameters, we can update either wasCorrect, Question, Answer of a card with this statement
            SqlParameter param = new SqlParameter("@isCorrect", cardToUpdate.CorrectlyAnswered == true ? 1 : 0);
            cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@q", cardToUpdate.Question);
            cmd.Parameters.AddWithValue("@a", cardToUpdate.Answer);
            cmd.Parameters.AddWithValue("@id", cardToUpdate.Id);

            using SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                reader.Read();

                card = new FlashCard {
                    Id = (int) reader["Id"],
                    Question = (string) reader["Question"],
                    Answer = (string) reader["Answer"],
                    CorrectlyAnswered = (bool) reader["WasCorrect"]
                };
            }
        }
        catch(SqlException)
        {
            throw;
        }

        return card;
    }
}