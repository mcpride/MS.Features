namespace MS.Features.Strategies
{
    public interface IStrategyWriter : IStrategy
    {
        void Write(bool state);
    }
}
