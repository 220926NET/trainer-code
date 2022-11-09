using System.Text;
using System.Reflection;

public class State<T> {

    public State(T entity) {
        Entity = entity;
        Status = "Unknown";
    }

    public State(T entity, string state) : this(entity) {
        Status = state;
    }
    public T Entity { get; set; }
    public string Status { get; set; }

    public override string ToString()
    {
        return $"Entity: \n{Entity?.ToString()} \nState: {Status}";
    }
}

public class ChangeTracker<T> {

    public Type Type { get; } = typeof(T);

    public List<State<T>> Collection = new();

    public void Get(T obj) {
        this.Collection.Add(new State<T>(obj, "Get"));
    }

    public void Add(T obj) {
        this.Collection.Add(new State<T>(obj, "Add"));
    }

    public void Remove(T obj) {
        this.Collection.Add(new State<T>(obj, "Remove"));
    }

    public void Update(T obj) {
        this.Collection.Add(new State<T>(obj, "Update"));
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        foreach(State<T> obj in Collection) {
            builder.Append(obj?.ToString());
            builder.Append('\n');
        }
        return builder.ToString();
    }
}

public class Context
{
    public ChangeTracker<User> Users { get; set; } = new();
    public ChangeTracker<Ticket> Tickets { get; set; } = new();

    public void Add(Object obj) {
        //First, determine what Type this obj is
        //Then find the appropriate property to insert this type with the status
        // Type objType = obj.GetType();
        // Console.WriteLine(objType);
        CallChangeTrackerMethods("Add", obj);
    }

    public void Remove(Object obj) {
        CallChangeTrackerMethods("Remove", obj);
    }

    public void Update(Object obj) {
        CallChangeTrackerMethods("Update", obj);
    }

    public void Get(Object obj) {
        CallChangeTrackerMethods("Get", obj);
    }

    private void CallChangeTrackerMethods(string methodName, Object obj) 
    {
        Type self = this.GetType();
        Type objType = obj.GetType();

        foreach(PropertyInfo prop in self.GetProperties()) {
            if(objType == GetChangeTrackerType(prop)) {
                // Console.WriteLine("found the change tracker associated with this type");
                prop.PropertyType.GetMethod(methodName)?.Invoke(prop.GetValue(this), new Object[] {obj});
            }
        }
    }

    private Type GetChangeTrackerType(PropertyInfo prop) {
        return prop.PropertyType.GetGenericArguments()[0];
    }
}