using System;
using System.Linq;
using MS.Features.Strategies;
using MS.Features.Strategies.Configuration;

namespace MS.Features
{
    public static class FeatureContextExtensionMethods
    {
        public static void DiscoverFeatures(this FeatureContext context)
        {
            foreach (var feature in TypeAttributeHelper.GetTypesChildOf<FeatureBase>())
            {
                context.AddFeature(feature);
            }
        }

        public static void DiscoverStrategies(this FeatureContext context)
        {
            var strategyConfigurations = TypeAttributeHelper.GetTypesChildOf<FeatureStrategyAttribute>();
            var strategyImplementations = TypeAttributeHelper.GetTypesChildOf<IStrategy>();

            foreach (var strategyConfiguration in strategyConfigurations)
            {
                var name = strategyConfiguration.Name;
                if (name.EndsWith("Attribute"))
                {
                    name = name.Substring(0, name.Length - 9);
                }
                var imlementationName = name + "Provider";
                // ReSharper disable PossibleMultipleEnumeration
                foreach (
                    var strategyImplementation in
                        strategyImplementations.Where(
                            strategyImplementation =>
                                strategyImplementation.Name.Equals(imlementationName, StringComparison.InvariantCulture))
                    )
                {
                    context.AdditionalStrategies[strategyConfiguration] = strategyImplementation;
                    break;
                }
                // ReSharper restore PossibleMultipleEnumeration
            }
        }
    }
}