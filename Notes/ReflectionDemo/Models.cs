public class User
{
    public User() {}
    public User(string name)
    {
        Name = name;
    }
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "";

    public string Role { get; set; } = "Employee";

    public override string ToString()
    {
        return $"Id: {Id} \nName:{Name} \nRole:{Role}";
    }
}

public class Ticket
{
    public Ticket() {}
    public Ticket(decimal amt)
    {
        Amount = amt;
    }

    public int Id { get; set; } = 0;
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public decimal Amount { get; set; } = 0.0m;
    public string Note { get; set;} = "";

    public override string ToString()
    {
        return $"Id: {Id} \nDateCreated: {DateCreated} \nAmount: {Amount} \nNote: {Note}";
    }
}