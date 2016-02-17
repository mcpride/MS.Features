namespace Rhenus.HD.Features.Strategies.Implementation
{
    public class AlwaysTrueStrategy : StrategyReaderBase
    {
        public override bool Read()
        {
            return true;
        }
    }
}
