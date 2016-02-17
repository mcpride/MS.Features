namespace MS.Features.Strategies.Providers
{
    public class AlwaysTrueStrategyProvider : StrategyReaderBase
    {
        public override bool Read()
        {
            return true;
        }
    }
}
