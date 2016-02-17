using MS.Features.Strategies;
using MS.Features.Strategies.Configuration;

namespace MS.Features
{
    public class StrategyTuple
    {
        public FeatureStrategyAttribute StrategyConfiguration { get; private set; }
        public IStrategy StrategyProvider { get; private set; }

        public StrategyTuple(FeatureStrategyAttribute strategyConfiguration, IStrategy strategyProvider)
        {
            StrategyProvider = strategyProvider;
            StrategyConfiguration = strategyConfiguration;
        }
    }
}
