namespace StructuralPatterns.Facade;
public interface IBankFacade
{
    Guid CreateAccount(string name, decimal? startMoney = null);
    void RemoveAccount(Guid id);
    bool TryRemoveAccount(Guid id);
    void WithdrawMoney(Guid id, decimal money);
    void DepositMoney(Guid id, decimal money);
    void Transfer(Guid from, Guid to, decimal money);
    void GetAccountInfo(Guid id);
}