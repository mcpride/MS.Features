using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MS.Features.Strategies;

namespace MS.Features
{
    public class FeatureSet
    {
        private readonly Dictionary<string, FeatureTuple> _features = new Dictionary<string, FeatureTuple>();

        public FeatureSet()
        {
            ConfigurationErrors = new Dictionary<string, string>();
        }

        public IDictionary<string, FeatureTuple> Features
        {
            get
            {
                return _features;
            }
        }

        public IDictionary<string, string> ConfigurationErrors { get; private set; }

        public void AddFeature<T>() where T : FeatureBase
        {
            AddFeature(typeof(T));
        }

        public void AddFeature(Type featureType)
        {
            var key = featureType.FullName;

            // add only if does not exist
            if (_features.ContainsKey(key))
            {
                return;
            }

            var featureInstance = (FeatureBase)Activator.CreateInstance(featureType);
            featureInstance.Name = featureType.Name;

            _features.Add(key, new FeatureTuple(featureInstance, new List<IStrategy>()));
        }

        public FeatureBase GetFeature<T>(bool throwNotFound = true) where T : FeatureBase
        {
            return GetFeature(typeof(T), throwNotFound).Feature;
        }

        public FeatureTuple GetFeature(Type feature, bool throwNotFound = true)
        {
            var item = GetFeatureWithStrategies(feature.FullName);
            if (item != null)
            {
                return item;
            }

            if (throwNotFound)
            {
                throw new KeyNotFoundException(string.Format(SR.ErrorMessageFeatureOfTypeXNotFound, feature));
            }

            return null;
        }

        public bool IsEnabled(Type feature)
        {
            if (ConfigurationErrors.Keys.Contains(feature.FullName, StringComparer.InvariantCultureIgnoreCase))
            {
                throw new ConfigurationErrorsException(ConfigurationErrors[feature.FullName]);
            }

            var f = GetFeature(feature, false);

            if (f == null)
            {
                return false;
            }

            var states = f.Strategies.Select(s =>
            {
                // test if strategy implementation is readable
                var reader = (s as IStrategyReader);
                return (reader != null) && reader.Read();
            });

            // feature is enabled if any of strategies is telling truth
            return states.Any(b => b);
        }

        public bool IsEnabled<T>() where T : FeatureBase
        {
            return IsEnabled(typeof(T));
        }

        public void ValidateConfiguration()
        {
            if (ConfigurationErrors.Any())
            {
                throw new ConfigurationErrorsException(string.Join("; ", ConfigurationErrors.Values.ToArray()));
            }
        }

        internal void ChangeEnabledState(string featureName, bool state)
        {
            var item = GetFeatureWithStrategies(featureName);

            if (item == null)
            {
                throw new KeyNotFoundException(string.Format(SR.ErrorMessageFeatureOfTypeXNotFound, featureName));
            }

            // find 1st writer strategy
            var writer = item.Strategies.FirstOrDefault(s => s is IStrategyWriter);
            if (writer == null)
            {
                throw new InvalidOperationException(string.Format(SR.ErrorMessageFeatureOfTypeXNotModifiable, featureName));
            }

            try
            {
                ((IStrategyWriter)writer).Write(state);
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch (Exception)
            // ReSharper restore EmptyGeneralCatchClause
            {
                // TODO: extension point for logging
            }
        }

        internal void ChangeEnabledState<T>(bool state) where T : FeatureBase
        {
            ChangeEnabledState(typeof(T).FullName, state);
        }

        private FeatureTuple GetFeatureWithStrategies(string featureName)
        {
            var featureEntry = _features.FirstOrDefault(f => f.Key != null && f.Key == featureName);
            return featureEntry.Key != null ? featureEntry.Value : null;
        }
    }
}
