namespace Models;

public class FlashCard
{
    public FlashCard() {}
    //constructor
    public FlashCard(string q, string a)
    {
        Question = q;
        Answer = a;
    }

    public int Id { get; set; }

    //properties
    private string _question = "";
    public string Question 
    { 
        get 
        {
            return _question;
        }
        set
        {
            //value is the thing user is trying to set the property as
            if(String.IsNullOrWhiteSpace(value))
            {
                //we're gonna throw some exception, regarding input validation
                throw new ArgumentException("Question must not be empty");
            }
            else
            {
                //we'll set the value they passed as our private field value
                _question = value;
            }
        }
    }

    private string _answer = "";
    public string Answer 
    { 
        get 
        {
            return _answer;
        }
        set
        {
            //value is the thing user is trying to set the property as
            if(String.IsNullOrWhiteSpace(value))
            {
                //we're gonna throw some exception, regarding input validation
                throw new ArgumentException("Answer must not be empty");
            }
            else
            {
                //we'll set the value they passed as our private field value
                _answer = value;
            }
        }
    }

    public bool CorrectlyAnswered { get; set; } = false;
}