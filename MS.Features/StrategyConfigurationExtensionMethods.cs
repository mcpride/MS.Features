using MS.Features.Strategies.Configuration;

namespace MS.Features
{
    public static class StrategyConfigurationExtensionMethods
    {
        public static StrategyConfigurationExpression<TStrategy> ForConfiguration<TStrategy>(
            this FeatureContext featureContext) where TStrategy : FeatureStrategyAttribute
        {
            return new StrategyConfigurationExpression<TStrategy>(featureContext);
        }
    }
}
