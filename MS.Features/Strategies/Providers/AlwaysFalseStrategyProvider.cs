namespace MS.Features.Strategies.Providers
{
    public class AlwaysFalseStrategyProvider : StrategyReaderBase
    {
        public override bool Read()
        {
            return false;
        }
    }
}
