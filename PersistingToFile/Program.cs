using System.Text.Json;

public class Pokemon
{
    public string Type { get; set; }
    public int BodyShape {get; set;}
    public string Name {get; set; }
    public int Level {get;set;}
    public int Id {get;set;}
    public int TrainerId {get;set;}
}

public class PokemonTrainer
{
    public int Id {get; set;}
    public string Name {get; set;}
    public List<string> Inventory { get; set; }
    public decimal PokeBucks { get; set; }
    public int NumBadges { get; set; }

    public List<Pokemon> Pokemons { get; set; }

    public int RivalId { get; set; }
}

//pokemon.json

class Program {
    public static void Main(string[] arg)
    {
        Pokemon pikachu = new Pokemon{
            Type = "Electric",
            BodyShape = 8,
            Name = "Pikachu",
            Level = 99,
            Id = 025,
            TrainerId = 1
        };

        PokemonTrainer rushay = new PokemonTrainer {
            Id = 1,
            Name = "Rushay",
            PokeBucks = 3000,
            NumBadges = 1,
            Inventory = new List<string> {"Hyper potion", "Master Ball", "Poke Flute"},
            Pokemons = new List<Pokemon> { pikachu },
        };

        PokemonTrainer duncan = new PokemonTrainer {
            Id = 2,
            Name = "Duncan",
            PokeBucks = 0,
            Inventory = new List<string> {"bike"},
            NumBadges = 2,
            Pokemons = new List<Pokemon> {
                new Pokemon {
                    Id = 6,
                    Type = "Fire, Flying",
                    Name = "Charizard",
                    Level = 36
                }
            }
        };
        rushay.RivalId = duncan.Id;
        duncan.RivalId = rushay.Id;
        
        string filePath = "./pokemon.json";
        if(!File.Exists(filePath))
        {   
            File.Create(filePath);
        }

        //At this point, we know the json file at ./pokemon.json exists
        //Now we're gonna serialize our C# objects to json, and ask File class to write that for us

        string jsonString = "";
        try
        {
            jsonString = JsonSerializer.Serialize(new List<PokemonTrainer>{duncan, rushay});
        }
        catch(JsonException ex)
        {
            Console.WriteLine("Something went wrong");
        }
        File.WriteAllText(filePath, jsonString);

        string readText = File.ReadAllText(filePath);
        List<PokemonTrainer> pokeTrainers = JsonSerializer.Deserialize<List<PokemonTrainer>>(readText);

        foreach(PokemonTrainer trainer in pokeTrainers)
        {
            Console.WriteLine(trainer.Name);
        }
    }
}