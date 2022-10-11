using Models;
using Microsoft.Data.SqlClient;

namespace DataAccess;

/*
ADO.NET : Which is a collection of classes and tools to interact with variety of data sources in uniform fashion
*/
public class FlashCardRepo : IFlashCardStorage
{
    private SqlConnection _connection;


    public FlashCardRepo(SqlConnection connection) {
        _connection = connection;
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
            _connection.Open();

            //very dangerous code, do not do this
            // SqlCommand cmd = new SqlCommand($"INSERT INTO FlashCards (Question, Answer) VALUES ('{cardToCreate.Question}', '{cardToCreate.Answer}')", connection);

            //preventing against sql injection
            using SqlCommand cmd = new SqlCommand("INSERT INTO FlashCards (Question, Answer) OUTPUT INSERTED.Id VALUES (@question, @answer);", _connection);
            cmd.Parameters.AddWithValue("@question", cardToCreate.Question);
            cmd.Parameters.AddWithValue("@answer", cardToCreate.Answer);

            int insertedId = (int) cmd.ExecuteScalar();
            cardToCreate.Id = insertedId;
        }
        catch(SqlException)
        {
            throw;
        }
        finally
        {
            _connection.Close();
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
            _connection.Open();

            using SqlCommand command = new SqlCommand("SELECT * FROM FlashCards;", _connection);

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
            _connection.Close();
        }

        return cards;
    }

    public FlashCard UpdateCard(FlashCard cardToUpdate)
    {
        FlashCard card = new();
        try
        {
            //open the connection
            _connection.Open();

            //assemble the sql statement
            using SqlCommand cmd = new SqlCommand("UPDATE FlashCards SET WasCorrect = @isCorrect, Question = @q, Answer = @a WHERE Id = @id; SELECT * FROM FlashCards WHERE Id = @id", _connection);

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
        finally
        {
            _connection.Close();
        }

        return card;
    }
}