using Models;
using System.Reflection;
// Pokemon poke = new Pokemon();
// int num = 3;

// Type pokeType = poke.GetType();
// PropertyInfo[] props = pokeType.GetProperties();
// MethodInfo[] methods = pokeType.GetMethods();
// foreach(PropertyInfo prop in props)
// {
//     Console.WriteLine(prop);
// }

// foreach(MethodInfo method in methods) {
//     Console.WriteLine(method);
// }
// Console.WriteLine(num.GetType());

// Console.WriteLine(typeof(Pokemon));

// State<Pokemon> pokeState = new(new Pokemon("Test Poke"));
// // pokeState.Entity = new Pokemon("Test poke");
// pokeState.Status = "Create";

// Console.WriteLine(pokeState);

// State<User> userState = new(new User());

// State<Ticket> tixState = new State<Ticket>(new Ticket());

ChangeTracker<User> userCT = new();

userCT.Add(new User());
userCT.Remove(new User());

// Console.WriteLine(userCT);

Context ctx = new Context();

// ctx.Users.Add(new User("Test User"));

ctx.Add(new Ticket());
ctx.Tickets.Add(new Ticket(3.33m));
// ctx.Add();

ctx.Remove(new Ticket());
ctx.Get(new User());
ctx.Add(1);

Console.WriteLine(ctx.Users);
Console.WriteLine(ctx.Tickets);