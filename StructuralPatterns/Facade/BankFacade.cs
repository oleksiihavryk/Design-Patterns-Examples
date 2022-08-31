namespace StructuralPatterns.Facade;

public class BankFacade : IBankFacade
{
    private readonly List<Account> _accounts = new List<Account>();

    public Guid CreateAccount(string name, decimal? startMoney = null)
    {
        var acc = startMoney == null ? 
            new Account(name) : 
            new Account(name, (decimal)startMoney);

        _accounts.Add(acc);
        
        return acc.Id;
    }
    public void RemoveAccount(Guid id)
    {
        var acc = _accounts.FirstOrDefault(a => a.Id == id)
            ?? throw new ArgumentOutOfRangeException(
                paramName: nameof(id), 
                message: "Account with current id is not found");

        _accounts.Remove(acc);
    }
    public bool TryRemoveAccount(Guid id)
    {
        var acc = _accounts.FirstOrDefault(a => a.Id == id);

        if (acc == null)
            return false;

        _accounts.Remove(acc);

        return true;
    }
    public void WithdrawMoney(Guid id, decimal money)
    {
        try
        {
            var acc = GetAccount(id);
            new WithdrawOperation(acc, money).Execute();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                message: "Some error in withdraw money operation", 
                innerException: ex);
        }
    }
    public void DepositMoney(Guid id, decimal money)
    {
        try
        {
            var acc = GetAccount(id);
            new DepositOperation(acc, money).Execute();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                message: "Some error in deposit money operation",
                innerException: ex);
        }
    }
    public void Transfer(Guid from, Guid to, decimal money)
    {
        try
        {
            var accFrom = GetAccount(from);
            var accTo = GetAccount(to);
            new TransferOperation(accFrom, accTo, money).Execute();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                message: "Some error in transfer money operation",
                innerException: ex);
        }
    }
    public void GetAccountInfo(Guid id)
    {
        var acc = GetAccount(id);
        Console.WriteLine(acc);
    }

    private Account GetAccount(Guid id)
        => _accounts.FirstOrDefault(a => a.Id == id)
           ?? throw new ArgumentOutOfRangeException(
               paramName: nameof(id),
               message: "Account with current id is not found");
}