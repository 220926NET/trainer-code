/*
Guessing Game:
Given a random positive integer, we'll prompt uses to guess the number
We can help users by letting them know how close they are to the number
as well as if they are lower or higher than the correct answer
It can also limit the number of guesses the users can use
and the program also tells the user when they got it right
Users can also restart the game once the current session is over
The game can also have High score feature
Limit on the range of the number 
Leaderboard?
Ability to users to name themselves
Ability to save the result in an external file (or db, or etc)
Different topic
*/

/*
User Stories
- Users should be able to submit their guess
- Users should be able to see if their guess is correct or not
- Users should be able to see if their guess is lower or higher than the correct number
- Users should be able to see how close their guess was to the correct answer (within 5, 10, etc. warm, cold, etc)
- Users should be able to know how many guesses they have left
- Users should be able to have an option to restart the game
- Users should be able to see their highest score
- Users should be able to know the range of the numbers 
- Users should be able to set the range of numbers
- Users should be able to see their past attempts
- Users shouldn't be able to enter invalid input 
- Users should be able to name themselves or remain anonymous
- Users should be able to see their records from prior sessions
- Users should be able to choose different topics
*/

/*
MVP: Minimum Viable Product
- We should be able to generate a random number (done)
- Users should be able to guess it (done)
* It would be nice to know if the guess was correct or not
*/

Random rnd = new Random();
int num = rnd.Next(100);

Console.WriteLine("Welcome to guessing game");
Console.WriteLine("Enter a guess: ");
string guess = Console.ReadLine();
int guessedNumber = int.Parse(guess);

if(num == guessedNumber)
{
    Console.WriteLine("You guessed correctly!");
}
else
{
    // Console.WriteLine("You guessed incorrectly, you are " + (num - guessedNumber) + " off");
    if(num > guessedNumber)
    {
        Console.WriteLine("You guessed incorrectly, your guess is low");
    }
    else
    {
        Console.WriteLine("You guessed incorrectly, your guess is high");
    }
}