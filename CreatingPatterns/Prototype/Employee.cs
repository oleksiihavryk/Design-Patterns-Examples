namespace CreatingPatterns.Prototype;
public class Employee : ICloneable
{
    private Office? _office;

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Office? Office
    {
        get => _office;
        set
        {
            _office?.Employees.Remove(this);

            if (value != null)
            {
                _office = value;
                _office.Employees.Add(this);
            }
        }
    }

    public Employee()
    {
    }
    public Employee(string name)
        : this(name, null)
    {
        
    }
    public Employee(string name, Office? office)
    {
        Id = Guid.NewGuid();
        Name = name;
        Office = office;
    }

    public object Clone() => new Employee(this.Name, this.Office);

    public override string ToString()
    {
        return $"Employee: {Name}, " + 
               (Office != null ? $"work in office by name: {Office?.Name}" :
                   "work not in office");
    }
}