using System.Globalization;

namespace StructuralPatterns.Facade;
internal class Account
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }

    public Account(string name)
        : this(name, 0m)
    {
    }
    public Account(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
        Id = Guid.NewGuid();
    }

    public override string ToString() 
        => $"{Name} - {String.Format(new CultureInfo("en-us"), "{0:C}", Balance)}";
}