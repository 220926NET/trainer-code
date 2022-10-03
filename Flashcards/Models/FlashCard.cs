namespace Models;

public class FlashCard
{
    public FlashCard() { }
    //constructor
    public FlashCard(string q, string a)
    {
        Question = q;
        Answer = a;
    }

    //properties
    public string Question { get; set; } = "";
    public string Answer { get; set; } = "";
}