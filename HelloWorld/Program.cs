// See https://aka.ms/new-console-template for more information
// This is our main entry point of the application
//The computer go here first to look for instructions to execute

Console.WriteLine("Hello, World!");

Cat auryn = new Cat();
Cat garfield = new Cat("orange");
Cat stinker = new Cat("orange", "short");
// auryn.volume = 20;
// auryn.furLength = "medium";
// auryn.Meow();
// // auryn.Meow(50);
// Cat garfield = new Cat();
// garfield.furLength = "short";
// garfield.volume = 70;
// // Console.WriteLine(auryn != garfield);
// garfield.Meow();
// Console.WriteLine(Cat.species);
Cat mayaTwo = new Cat();
mayaTwo.EyeColor = "Yellow";

//Object Initializer Syntax (another shorthand)
Cat maya = new Cat {
    EyeColor = "Yellow"
};

//also object initializer
int[] intArr = new int[5] {1, 2, 3, 4, 5};

auryn.EyeColor = "Green";
auryn.EyeColor = "              ";
Console.WriteLine(auryn.EyeColor);
public class Cat
{
    public Cat() {}
    public Cat(string color)
    {
        this.color = color;
    }

    public Cat(string color, string furLength)
    {
        this.color = color;
        this.furLength = furLength;
    }
    private static string species = "felix domesticus";
    private string furLength;
    private string color;
    private int tailLengthInInches;
    private double volume;
    private int brokenThings = 0;

    private string _eyeColor = "Yellow";
    //custom getters and setters and input validation
    public string EyeColor { 
        get 
        {
            return this._eyeColor;
        }
        set {
            if(!String.IsNullOrWhiteSpace(value))
            {
                this._eyeColor = value;
            }
        }
    }
    
    //Automatic property
    public string Mood { get; set; } = "docile";


    //method
    //method signature access mod, return type, method name, parameters
    public void SetTailLengthInInches(int length)
    {
        if(length < 0) return;
        else this.tailLengthInInches = length;
    }

    //expression body, another shorthand for simple methods
    public int GetTailLengthInInches() => this.tailLengthInInches; 
    // {
    //     return this.tailLengthInInches;
    // }

    //Example of method overloading (a form of polymorphism)
    public void Meow()
    {
        if(this.volume != 0)
        {
            this.Meow(this.volume);
        }
        else
        {
            Console.WriteLine("Meow");
        }
    }
    public void Meow(double volume)
    {
        if(volume < 30) 
        { 
            Console.WriteLine("mew");
        }
        else if(volume >= 30 && volume < 60)
        {
            Console.WriteLine("MROOw");
        }
        else if(volume >= 60 && volume < 80)
        {
            Console.WriteLine("RAWWWRRRR");
        }
        else
        {
            Console.WriteLine("**Pain**");
        }
    }
    public int BreakThings()
    {
        this.brokenThings++;

        return this.brokenThings;
    }
}

