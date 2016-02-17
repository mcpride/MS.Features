namespace MS.Features.Strategies
{
    public abstract class StrategyBase : StrategyReaderBase, IStrategyWriter
    {
        public abstract void Write(bool state);
    }
}
