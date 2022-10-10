namespace RestaurantReviews;

public class Review {

    //empty constructor
    public Review() { }

    //Example of constructor overloading
    public Review(int rating)
    {
        this.Rating = rating;
    }

    public Review(int rating, string note)
    {
        this.Rating = rating;
        this.Note = note;
    }

    public int Rating { get; set; }
    public string Note { get; set; }
}