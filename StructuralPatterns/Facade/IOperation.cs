namespace StructuralPatterns.Facade;

internal interface IOperation
{
    bool IsExecuted { get; }

    void Execute();
    void Revert();
}