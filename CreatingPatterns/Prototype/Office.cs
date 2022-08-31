namespace CreatingPatterns.Prototype;

public class Office
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Employee> Employees { get; set; }

    public Office()
    {
    }
    public Office(string name)
        :this (name, Enumerable.Empty<Employee>().ToList())
    {
    }
    public Office(
        string name,
        List<Employee> employees)
    {
        Id = Guid.NewGuid();
        Name = name;
        Employees = employees;
    }

    public override string ToString()
    {
        return $"Office: {Name}, Count of employees: {Employees.Count()}";
    }
}