using Models;
using Microsoft.Data.SqlClient;
using CustomExceptions;
using System.Data;

namespace DataAccess;

/**
* ADO.NET: is a collection of libraries that helps developers write data access code in a uniform fashion regardless of what data source they are dealing with
* All you need to be able to work with diff data source is a driver that is suited for a particular data source. For example, for SQL Server, we need Microsoft.Data.SqlClient. Install that to DL by navigating to DL folder and running dotnet add package Microsoft.Data.SqlClient.
* Two architecture styles: Connected and Disconnected
* Connected Architecture: We use objects such as DBConnection, DBCommand, DataReader to access data while we're connected to the database. DataReader is much faster at reading large amount of data compared to Disconnected Architecture.
* Disconnected Architecture: We use objects such as Data Adapter and DataSet (is like a bucket for the data) to have access to the data even when we're not connected to the db. The advantage of using DataAdapter, is that we have access to the schema of result set, so we can refer to the column by their name, instead of accessing by index as well as being able to automatically generate SqlCommands
*/
public class PokemonTrainerRepository : IPokemonTrainerRepository
{
    private readonly ConnectionFactory _connectionFactory;

    //for use with console application and reading connection string from a file
    public PokemonTrainerRepository()
    {
        _connectionFactory = ConnectionFactory.GetInstance(File.ReadAllText("../DataAccess/connectionString.txt"));
    }
    //To use with asp.net core application, reading the connection string from the appsettings.json and utilizing asp.net core's dep injector
    public PokemonTrainerRepository(ConnectionFactory factory)
    {
        _connectionFactory = factory;
    }

    /// <summary>
    /// Returns all pokemon trainer records
    /// </summary>
    /// <returns>List of pokemon trainers</returns>
    public List<PokeTrainer> GetAllTrainers()
    {
        List<PokeTrainer> trainers = new List<PokeTrainer>();
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("Select * From PokeTrainer", conn);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            trainers.Add(new PokeTrainer
            {
                Id = (int)reader["trainer_id"],
                Name = (string)reader["trainer_name"],
                Money = Convert.ToDecimal((double)reader["trainer_money"]),
                DoB = (DateTime) reader["date_of_birth"]
            });
        }
        reader.Close();
        conn.Close();

        return trainers;
    }

    /// <summary>
    /// Get Pokemon Trainer by name
    /// </summary>
    /// <param name="name">exact name to search for</param>
    /// <returns>found Pokemon trainer object</returns>
    /// <exception cref="RecordNotFoundException">when there is no trainer with such name</exception>
    public async Task<PokeTrainer> GetPokeTrainer(string name)
    {
        PokeTrainer foundTrainer;
        SqlConnection conn = _connectionFactory.GetConnection();
        conn.Open();

        //security hazard - do not do this
        // SqlCommand cmd = new SqlCommand($"Select * From PokeTrainer Where trainer_name = '{name}'", conn);

        //do this instead to prevent against sql injection
        SqlCommand cmd = new SqlCommand("Select * From PokeTrainer Where trainer_name = @name", conn);

        // SqlParameter param = new SqlParameter("@name", name);
        // cmd.Parameters.Add(param);

        cmd.Parameters.AddWithValue("@name", name);

        SqlDataReader reader = cmd.ExecuteReader();

        //while there are more rows to read
        while(await reader.ReadAsync())
        {
            return new PokeTrainer
            {
                Id = (int)reader["trainer_id"],
                Name = (string)reader["trainer_name"],
                Money = Convert.ToDecimal((double)reader["trainer_money"]),
                DoB = (DateTime)reader["date_of_birth"]
            };
        }

        //if we get here, we know that we haven't found any trainer with such name
        throw new RecordNotFoundException("Could not find the pokemon trainer with such name");
    }

    /// <summary>
    /// Gets pokemon trainer by its unique id
    /// </summary>
    /// <param name="id">integer id to search for</param>
    /// <returns>found poke trainer, if not null</returns>
    public PokeTrainer GetPokeTrainer(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a new pokemon trainer record to db
    /// </summary>
    /// <param name="newTrainerToRegister">new PokeTrainer record to add</param>
    /// <returns>the same trainer, with the generated id</returns>
    public PokeTrainer AddPokeTrainer(PokeTrainer newTrainerToRegister)
    {
        //disconnected architecture ADO.NET
        //DataSet is a container for the data adapter to fill with data it fetches with the select command
        DataSet pokeTrainerSet = new DataSet();

        SqlDataAdapter trainerAdapter = new SqlDataAdapter("Select * From PokeTrainer",  _connectionFactory.GetConnection());

        trainerAdapter.Fill(pokeTrainerSet, "trainerTable");

        // question mark(?) after a reference type makes it nullable as in, this trainerTable variable can either be DataTable or null
        DataTable? trainerTable = pokeTrainerSet.Tables["trainerTable"];

        if(trainerTable != null)
        {
            DataRow newTrainer = trainerTable.NewRow();
            newTrainer["trainer_name"] = newTrainerToRegister.Name;
            newTrainer["trainer_money"] = newTrainerToRegister.Money;
            newTrainer["num_badges"] = newTrainerToRegister.NumBadges;
            newTrainer["date_of_birth"] = newTrainerToRegister.DoB;

            trainerTable.Rows.Add(newTrainer);

            SqlCommand insertCommand = new SqlCommand("Insert into PokeTrainer (trainer_name, trainer_money, num_badges) OUTPUT INSERTED.trainer_id values (@name, @money, @badges)", _connectionFactory.GetConnection());
            insertCommand.Parameters.Add("@name", SqlDbType.VarChar, 30, "trainer_name");
            insertCommand.Parameters.Add("@money", SqlDbType.Float, 32, "trainer_money");
            insertCommand.Parameters.Add("@badges", SqlDbType.Int, 50, "num_badges");

            // SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(trainerAdapter);
            // SqlCommand insertCommand = cmdbuilder.GetInsertCommand();

            //assign the command we just created to use to insert new records to this adapter
            trainerAdapter.InsertCommand = insertCommand;
            //persist changes to the db
            trainerAdapter.Update(trainerTable);
            
            newTrainerToRegister.Id = (int) newTrainer["trainer_id"];
        }
        return newTrainerToRegister;
    }
}