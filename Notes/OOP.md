# Object Oriented Programming

## Class
Is a blueprint for an object

### Class Members
Are things that belong in a class
- Fields : they describe the traits
    - they hold the data in classes
- Methods: They describe the behavior

```csharp
public class Cat
{
    public string furLength;
    public string color;
    public int tailLengthInInches;
    public double volume;
    public string mood;
    public int brokenThings = 0;

    //Example of method overloading (a form of polymorphism)
    public void Meow()
    {
        if(this.volume != 0)
        {
            this.Meow(this.volume)
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
        brokenThings++;

        return this.brokenThings;
    }
}

```

## Reference vs Value Types
There are two types of memory storage in a program: Stack and heap
in stack, we store the variable declaration (Cat auryn, int n, bool isTrue)
in the case of value types (char, bool, int, short, long, decimal, double, float, etc.) the program stores the value of the variable (3 for int n, alongside the declaration). The runtime doesn't have to go anywhere else to find the value of the variable.
For reference types (Object, class, array, etc.) the value of the variable, is stored in heap and the memory address to there (the space in heap where the actual value exists) is stored in the stack, alongside with the variable declaration.
Sometimes, we need to convert value types to references types. In that case, we do the operation called "boxing" and "box" the value type in Object. The process of wrapping a value type in object is called boxing, the process of undoing boxing is "unboxing".

List<Cat> catList = new List<Cat> {cat1, cat2, cat3}

catList is a type of List of cats, and here is where you go to find this list

## Garbage Collection (aka automatic memory management)
This is one of the features of CLR (Common Language Runtime, runtime for .NET Platform) where the runtime will periodically scan the memory and clear objects that are no longer being used. Helps with memory leak.

