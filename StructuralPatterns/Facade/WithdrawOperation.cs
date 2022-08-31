namespace StructuralPatterns.Facade;
internal class WithdrawOperation
{
    private int _execCounter = 0;
    private bool _isExecuted = false;

    private readonly Account _from;
    private readonly decimal _howMuch;

    public bool IsExecuted => _isExecuted;

    public WithdrawOperation(
        Account from,
        decimal howMuch)
    {
        if (howMuch < 0)
            throw new ArgumentOutOfRangeException(nameof(howMuch));

        if (from.Balance < howMuch)
            throw new ArgumentException(
                $"Argument {nameof(howMuch)} cannot be less than " +
                $"account from which deposit money have on balance.");

        _from = from;
        _howMuch = howMuch;
    }

    public void Execute()
    {
        //operation
        _from.Balance -= _howMuch;

        //post
        if (!IsExecuted)
            _isExecuted = true;
        _execCounter++;
    }
    public void Revert()
    {
        if (IsExecuted)
        {
            _from.Balance += _howMuch;

            if (--_execCounter == 0)
                _isExecuted = false;
        }
    }
}