using System;
using MS.Features.Strategies;
using MS.Features.Strategies.Configuration;

namespace MS.Features
{
    public class StrategyConfigurationExpression<TStrategy> where TStrategy : FeatureStrategyAttribute
    {
        private readonly FeatureContext _context;

        public StrategyConfigurationExpression(FeatureContext context)
        {
            _context = context;
        }

        public void Use(Type implementation)
        {
            if (!implementation.IsSubclassOf(typeof (IStrategy)))
            {
                throw new InvalidCastException(string.Format(SR.ErrorMessageTypeXDoesNotInheritFromTypeY, implementation.Name, "IStrategy"));
            }
            var strategyType = typeof(TStrategy);
            _context.AdditionalStrategies[strategyType] = implementation;
        }

        public void Use<T>() where T : IStrategy
        {
            var strategyType = typeof(TStrategy);
            _context.AdditionalStrategies[strategyType] = typeof(T);
        }
    }
}
