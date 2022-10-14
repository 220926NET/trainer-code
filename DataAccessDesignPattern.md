# Design Patterns for Data Access Logic

## Repository Pattern
- This is a design pattern that provides all data access related operations in an abstracted way
```csharp
public class RepositoryPattern
{
    List<Ticket> GetAll() {}
    Ticket GetOneById(int id) {}
    Ticket CreateTicket (Ticket newTix) {}
    Ticket UpdateTicket (Ticket updateTix) {}
    Ticket DeleteTicket (int id) {}
}
```
- You can make this class specific, or make it generic repository pattern
```csharp
public class Repository<T>
{
    List<T> GetAll() {}
    T Create(T entity) {}
    //so on and so forth..
}
```

## Unit of Work Pattern
 - Repository + Transaction
 - It provides a central "dbContext"(which is sort of like a work queue) between multiple repositories, where different repositories can add their work to be performed (insert, update, delete, etc.). Once they call "save changes/update" on dbContext, that particular object will ensure that the work is being completed as whole
 - Some Links
    - https://www.c-sharpcorner.com/UploadFile/b1df45/unit-of-work-in-repository-pattern/