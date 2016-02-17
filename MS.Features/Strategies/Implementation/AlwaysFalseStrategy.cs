namespace Rhenus.HD.Features.Strategies.Implementation
{
    public class AlwaysFalseStrategy : StrategyReaderBase
    {
        public override bool Read()
        {
            return false;
        }
    }
}
