using System;
using System.Collections.Generic;
using System.Linq;
using MS.Features.Strategies;
using MS.Features.Strategies.Configuration;
using MS.Features.Strategies.Providers;

namespace MS.Features
{
    public class FeatureSetBuilder
    {
        private readonly Dictionary<Type, Type> _strategyImplementations = new Dictionary<Type, Type>();
        //{
        //    { typeof(AppSettingsAttribute), typeof(AppSettingsStrategy) },
        //    { typeof(AlwaysTrueAttribute), typeof(AlwaysTrueStrategy) },
        //    { typeof(AlwaysFalseAttribute), typeof(AlwaysFalseStrategy) }
        //};

        public FeatureSet Build(Action<FeatureContext> action = null)
        {
            var context = SetupFeatureContext(action);
            SetupStrategies(context);
            BuildFeatureSet(context);

            FeatureContext.SetInstance(context);

            return context.Container;
        }

        protected void SetupStrategies(FeatureContext context)
        {
            foreach (var readerKeyValuePair in context.AdditionalStrategies)
            {
                var strategyType = readerKeyValuePair.Key;
                var strategyReaderType = readerKeyValuePair.Value;
                _strategyImplementations[strategyType] = strategyReaderType;
            }
        }

        protected FeatureContext SetupFeatureContext(Action<FeatureContext> action)
        {
            var context = new FeatureContext();
            if (action != null)
            {
                // if configuration expression is present - call that one
                action(context);
            }
            else
            {
                // otherwise we are going to scan for all features exposed and add to the context
                context.DiscoverFeatures();
                context.DiscoverStrategies();
            }
            return context;
        }

        internal IStrategy GetStrategyImplementation(Type strategyType)
        {
            Type reader;
            if (_strategyImplementations.TryGetValue(strategyType, out reader))
            {
                return (IStrategy) Activator.CreateInstance(reader);
            }
            return new EmptyStrategyProvider();
        }

        internal IStrategy GetStrategyImplementation<T>()
        {
            return GetStrategyImplementation(typeof(T));
        }

        private void BuildFeatureSet(FeatureContext context)
        {
            foreach (var keyValuePair in context.Container.Features)
            {
                var feature = keyValuePair.Value.Feature;
                var strategies = feature.GetType()
                                        .GetCustomAttributes(typeof(FeatureStrategyAttribute), true)
                                        .Cast<FeatureStrategyAttribute>()
                                        .OrderBy(a => a.Order);

                if (!strategies.Any())
                {
                    continue;
                }

                if (strategies.GroupBy(a => a.Order).Any(k => k.Count() > 1))
                {
                    feature.ChangeIsProperlyConfiguredState(false);
                    context.AddConfigurationError(feature, string.Format(SR.ErrorMessageFeatureStrategiesWithSameOrder, keyValuePair.Key));
                    continue;
                }

                var strategyImplementations = strategies.Select(s => new StrategyTuple(s, GetStrategyImplementation(s.GetType()))).ToList();
                keyValuePair.Value.Strategies.Clear();
                strategyImplementations.ForEach(i =>
                {
                    i.StrategyProvider.Initialize(i.StrategyConfiguration.BuildConfigurationContext());
                    keyValuePair.Value.Strategies.Add(i.StrategyProvider);
                });

                feature.ChangeModifiableState(strategyImplementations.Any(s => s.StrategyProvider is IStrategyWriter));
            }
        }
    }
}
