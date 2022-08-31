namespace StructuralPatterns.Facade;
internal class DepositOperation : IOperation
{
    private int _execCounter = 0;
    private bool _isExecuted = false;

    private readonly Account _to;
    private readonly decimal _howMuch;
    
    public bool IsExecuted => _isExecuted;

    public DepositOperation(
        Account to, 
        decimal howMuch)
    {
        if (howMuch < 0)
            throw new ArgumentOutOfRangeException(nameof(howMuch));

        _to = to;
        _howMuch = howMuch;
    }

    public void Execute()
    {
        //operation
        _to.Balance += _howMuch;

        //post
        if (!IsExecuted)
            _isExecuted = true;
        _execCounter++;
    }

    public void Revert()
    {
        if (IsExecuted)
        {
            _to.Balance -= _howMuch;

            if (--_execCounter == 0)
                _isExecuted = false;
        }
    }
}