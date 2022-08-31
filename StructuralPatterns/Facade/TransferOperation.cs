namespace StructuralPatterns.Facade;
internal class TransferOperation : IOperation
{
    private int _execCounter = 0;
    private bool _isExecuted = false;

    private readonly DepositOperation _depOp;
    private readonly WithdrawOperation _withOp;

    public bool IsExecuted => _isExecuted;

    public TransferOperation(
        Account from, 
        Account to, 
        decimal howMuch)
    {
        _depOp = new DepositOperation(to, howMuch);
        _withOp = new WithdrawOperation(from, howMuch);
    }

    public void Execute()
    {
        //operation
        _withOp.Execute();
        _depOp.Execute();

        //post
        if (!IsExecuted)
            _isExecuted = true;
        _execCounter++;
    }
    public void Revert()
    {
        if (IsExecuted)
        {
            _withOp.Revert();
            _depOp.Revert();

            if (--_execCounter == 0)
                _isExecuted = false;
        }
    }
}