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
- Users should be able to see their previous attempts
*/

/*
MVP: Minimum Viable Product
- We should be able to generate a random number (done)
- Users should be able to guess it (done)
* It would be nice to know if the guess was correct or not
*/

/*
I want to implement a feature that tells the user if they are getting closer or further away from the answer
- comparison between the correct number and the guess
- comparison between the last guess to my current guess

When a user guesses a number
0. We should first compare if they have it right
if not
1. this is their first guess
    1. I want to let them know if their guess is high or low
2. this is not their first guess
    0. Let them know if their guess is high or low
    1. I'll take the previous guess, n, and compare if the distance from n to the answer, a, is greater than or less than or equal to the distance from the current guess, m, to a, the answer.
        1. d_n < d_m : you're getting colder, aka, your new answer is further away from a than your previous answer
        2. d_n > d_m : you're getting warmer
        3. d_n == d_m : it's the same, you are not getting any closer
*/
Random rnd = new Random();
int answer = rnd.Next(100);

Console.WriteLine("Welcome to guessing game");

int? pastGuess = null;
int currentGuess = int.MaxValue; 
string guess;
while(true) 
{
    if(currentGuess != int.MaxValue)
    {
        pastGuess = currentGuess;
    }

    Console.WriteLine("Enter a guess: ");
    guess = Console.ReadLine();
    currentGuess = int.Parse(guess);
    if(GuessingGame.HighOrLow(answer, currentGuess) == 0)
    {
        Console.WriteLine("You guessed correctly!");
        break;
    }
    else if(GuessingGame.HighOrLow(answer, currentGuess) > 0)
    {
        Console.WriteLine("You guessed incorrectly, your guess is low");
    }
    else
    {
        Console.WriteLine("You guessed incorrectly, your guess is high");
    }

    Console.WriteLine("Past Guess: " + pastGuess + " Current guess: " + currentGuess);

    if(pastGuess != null)
    {
        int pastDiff = Math.Abs((int) (answer - pastGuess));
        int currDiff = Math.Abs((int) (answer - currentGuess));
        if(pastDiff > currDiff)
        {
            Console.WriteLine("You are getting warmer");
        }
        else if(pastDiff < currDiff)
        {
            Console.WriteLine("You are getting colder");
        }
        else
        {
            Console.WriteLine("You are as warm as the last guess");
        }
    }
}


public static class GuessingGame
{
    /// <summary>
    /// This method, takes in a number, and the answer, and returns a boolean, saying if it's the same or not
    /// </summary>
    /// <returns>Boolean value of whether the answer and the guess is the same</returns>
    //This is method, method "modularizes" "bundles" "encapsulates" a certain repeatable behavior
    // Method signature is the first line of the method definition
    //and it comprises of the following: Access modifier, non-access modifier (optional), return type, method name, method parameters(input values)
    public static bool IsCorrect(int answer, int? guess)
    {
        if(guess == null) return false;
        bool isCorrect = answer == guess;
        return isCorrect;
    }

    /// <summary>
    /// This method computes whether the guess was higher or lower than the answer provided
    /// It returns a number less than 0 if the guess is lower than the answer
    /// a number greater than 0 if the guess is higher than the answer
    /// returns 0 if the guess is the same as the answer
    /// </summary>
    /// <param name="answer">is integer value representing the correct answer of the game</param>
    /// <param name="guess">is the integer value representing the user's guess</param>
    public static int HighOrLow(int answer, int guess)
    {
        // if(answer > guess) return -1;
        // else if(answer < guess) return 1;
        // else return 0;

        return guess - answer;
    }
}