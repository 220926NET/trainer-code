# Recursion
is a way of solving a problem by breaking down a smaller problem

## Base Case
is a smallest problem that will not recurse

5! =  5 * 4 * 3 * 2  *1
5! = 5 * 4!
    = 5 * 4 * (3!)
    = 5 * 4 * 3 * 2!
    = 5 * 4 * 3 * 2 * 1!
    = 5 * 4 * 3 * 2 * 1

In this factorial example, 1 is our base case

## Recurrence Relation / Recursive Structure
This is the step where you call on the function itself to recurse

## Problems we can solve with recursion
- Factorial:
    - n! = n * (n-1)! 1! = 1
- Fibonacci Sequence: 
    - f_n+2 = f_n+1 + f_n where f_0 = 1, f_1 = 1
- Multiplication
    - 5 * 3 = 5 + 5 + 5
            = 5 + (5 * 2)
    - n * m = n + (n * (m - 1))

## Resources
- [Enjoy Algorithms](https://www.enjoyalgorithms.com/)
- [EA: Recursion](https://www.enjoyalgorithms.com/blog/recursion-explained-how-recursion-works-in-programming/)
- [EA: DSA](https://www.enjoyalgorithms.com/data-structures-and-algorithms-course/)
- [EA: OOP](https://www.enjoyalgorithms.com/oops-course/)
- [LeetCode: Recursion I](https://leetcode.com/explore/learn/card/recursion-i/)
- [LeetCode: Recursion Problems](https://leetcode.com/tag/recursion/)

## Exercises
- [LeetCode: Pow(x, n)](https://leetcode.com/problems/powx-n/)
- [LeetCode: Fibonacci](https://leetcode.com/problems/fibonacci-number/)

## Exercises we did together
```csharp
using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine(Multiply(15, 3));
	
		RussianDoll outerDoll = new RussianDoll();
		outerDoll.InnerDoll = new RussianDoll();
		outerDoll.InnerDoll.InnerDoll = new RussianDoll();
//		outerDoll.InnerDoll.InnerDoll.InnerDoll = new RussianDoll();
//		outerDoll.InnerDoll.InnerDoll.InnerDoll.InnerDoll = new RussianDoll();

		
		Console.WriteLine(CountRussianDolls(outerDoll));
	}

	private static int Multiply(int x, int y)
	{
		//base
		if(y == 1) return x;
		
		//recursive step
		return x + Multiply(x, y - 1);
	}
	
	private static int CountRussianDolls(RussianDoll doll)
	{
		//base case
		if(doll.InnerDoll == null) return 1;
		
		//recursion
		return 1 + CountRussianDolls(doll.InnerDoll);
	}
}

public class RussianDoll
{
	public RussianDoll InnerDoll;
}
```