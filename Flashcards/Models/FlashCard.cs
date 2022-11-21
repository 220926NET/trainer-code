using System.ComponentModel.DataAnnotations;

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

    // //properties
    // private string _question = "";
    // public string Question 
    // { 
    //     get 
    //     {
    //         return _question;
    //     }
    //     set
    //     {
    //         //value is the thing user is trying to set the property as
    //         if(String.IsNullOrWhiteSpace(value))
    //         {
    //             //we're gonna throw some exception, regarding input validation
    //             throw new ArgumentException("Question must not be empty");
    //         }
    //         else
    //         {
    //             //we'll set the value they passed as our private field value
    //             _question = value;
    //         }
    //     }
    // }
    [Required]
    [MaxLength(255)]
    public string Question { get; set; }
    
    [Required]
    public string Answer { get; set; }

    // private string _answer = "";
    // public string Answer 
    // { 
    //     get 
    //     {
    //         return _answer;
    //     }
    //     set
    //     {
    //         //value is the thing user is trying to set the property as
    //         if(String.IsNullOrWhiteSpace(value))
    //         {
    //             //we're gonna throw some exception, regarding input validation
    //             throw new ArgumentException("Answer must not be empty");
    //         }
    //         else
    //         {
    //             //we'll set the value they passed as our private field value
    //             _answer = value;
    //         }
    //     }
    // }

    public bool CorrectlyAnswered { get; set; } = false;

    public string Category { get; set; } = "";
    
    public override string ToString()
    {
        return $"{Question}: {Answer}";
    }

    //Use this method to implement your own value comparison logic for your reference type
    public override bool Equals(Object? obj)
    {
        //If this object is not null and the type of the object we're comparing is the same as the type of this current object
        if(obj != null && obj.GetType() == this.GetType())
        {
            //First, convert it to FlashCard type
            FlashCard cardToCompare = (FlashCard) obj;
            return cardToCompare.Id == this.Id && cardToCompare.Question == this.Question && cardToCompare.Answer == this.Answer;
        }
        return false;
    }
}