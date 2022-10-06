using RestaurantReviews;

//initialize my list of restaurants
List<Restaurant> allRestaurants = new List<Restaurant>();
bool exit = false;
Console.WriteLine("Welcome to Restaurant Reviews!");

while(!exit)
{
    Console.WriteLine("What would you like to do today?");
    Console.WriteLine("1. Create a new Restaurant");
    Console.WriteLine("2. View All Restaurant");
    Console.WriteLine("3. Leave a review");
    Console.WriteLine("x. Exit");
    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.WriteLine("Create a new restaurant:");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("City: ");
            string city = Console.ReadLine();
            Console.WriteLine("State: ");
            string state = Console.ReadLine();

            //Initializing the class using empty constructor
            // Restaurant newRestaurant = new Restaurant();
            // newRestaurant.Name = name;
            // newRestaurant.City = city;
            // newRestaurant.State = state;

            //another way to initialize a class
            //using object initializer
            Restaurant newRestaurant = new Restaurant {
                Name = name,
                City = city,
                State = state
            };

            allRestaurants.Add(newRestaurant);
        break;
        case "2":
            Console.WriteLine("Here are all your restaurants!");
            foreach(Restaurant resto in allRestaurants)
            {
                Console.WriteLine($"Name: {resto.Name} \nCity: {resto.City} \nState: {resto.State}");
                Console.WriteLine("======Reviews======");
                foreach(Review review in resto.Reviews)
                {
                    Console.WriteLine($"Rating: {review.Rating} \t Note: {review.Note}");
                }
            }
        break;
        case "3":
            Console.WriteLine("Select a restaurant to leave reviews for");
            for(int i = 0; i < allRestaurants.Count; i++)
            {
                Console.WriteLine($"[{i}] Name: {allRestaurants[i].Name} \nCity: {allRestaurants[i].City} \nState: {allRestaurants[i].State}");
            }
            int selection = Int32.Parse(Console.ReadLine());
            Restaurant selectedRestaurant = allRestaurants[selection];

            //now I want to collect information about the review
            Console.WriteLine("Give a rating: ");
            int rating = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Leave a Review: ");
            string note = Console.ReadLine();

            Review newReview = new Review(rating, note);

            selectedRestaurant.Reviews.Add(newReview);
            Console.WriteLine("Your review has been successfully added!");
        break;
        case "x":
            exit = true;
            Console.WriteLine("goodbye!");
        break;

    }
}