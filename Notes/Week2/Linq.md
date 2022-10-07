# LINQ (Language INtegrated Query)

## Extension Methods
## Delegates

Its a namespace, and a collection of methods that you can use to *uniformly* interact with various data sources.

As long as the collection of data implements IEnummerable or IQueryable, you can linq methods on them.

- Select
- Min
- Average
- OrderBy
- Count
- Where
- FirstOrDefault
- Max
- Sum
- and more

- Linq provides these functionalities via extension methods
- By default, these extension methods will return IEnumerable/IQueryable, int, the type in the collection
    - To convert IEnumerable<T> to List, ToList()
    - to get that to array, there is ToArray()

- Query Syntax
    ```csharp
        List<string> my_list = new List<string>() 
        {
                "This is my Dog",
                "Name of my Dog is Robin",
                "This is my Cat",
                "Name of the cat is Mewmew"
        };
  
        // Creating LINQ Query
        var res = from l in my_list
                  where l.Contains("my")
                  select l;
  
        // Executing LINQ Query
        foreach(var q in res)
        {
            Console.WriteLine(q);
        }

    ```
- Method syntax
    ```csharp
        List<string> strList = new List<string> {"one", "two", "three", "four", "five"};
		var filteredList = strList.Where(s => s.Length > 3);

		foreach(string s in filteredList)
		{
			Console.WriteLine(s);
		}
    ```