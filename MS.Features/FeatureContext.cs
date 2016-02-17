using System;
using System.Collections.Generic;
using System.Linq;

namespace MS.Features
{
    public class FeatureContext
    {
        private readonly Dictionary<Type, Type> _additionalStrategies = new Dictionary<Type, Type>();
        private static readonly object SyncRoot = new object();
        private static FeatureContext _instance = new FeatureContext();

        public FeatureContext()
        {
            Container = new FeatureSet();
        }

        public FeatureSet Container { get; private set; }

        internal IDictionary<Type, Type> AdditionalStrategies
        {
            get
            {
                return _additionalStrategies;
            }
        }

        internal void AddConfigurationError(FeatureBase feature, string error)
        {
            Container.ConfigurationErrors.Add(feature.GetType().FullName, error);
        }

        public void AddFeature<T>() where T : FeatureBase
        {
            AddFeature(typeof(T));
        }

        public void AddFeature(Type featureType)
        {
            Container.AddFeature(featureType);
        }

        public static void Disable<T>() where T : FeatureBase
        {
            Disable(typeof(T).FullName);
        }

        public static void Disable(string featureName)
        {
            CheckInstance();
            _instance.Container.ChangeEnabledState(featureName, false);
        }

        public static void Enable<T>() where T : FeatureBase
        {
            Enable(typeof(T).FullName);
        }

        public static void Enable(string featureName)
        {
            CheckInstance();
            _instance.Container.ChangeEnabledState(featureName, true);
        }

        public static FeatureBase GetFeature<T>(bool throwNotFound = true) where T : FeatureBase
        {
            return GetFeature(typeof(T), throwNotFound);
        }

        public static FeatureBase GetFeature(Type feature, bool throwNotFound = true)
        {
            return _instance.Container.GetFeature(feature, throwNotFound).Feature;
        }

        public static IList<FeatureBase> GetFeatures()
        {
            return _instance.Container.Features.Values.Select(t => t.Feature).ToList();
        }

        public static bool IsEnabled(FeatureBase feature)
        {
            return IsEnabled(feature.GetType());
        }

        public static bool IsEnabled(Type feature)
        {
            CheckInstance();
            return _instance.Container.IsEnabled(feature);
        }

        public static bool IsEnabled<T>() where T : FeatureBase
        {
            return IsEnabled(typeof(T));
        }

        internal static void SetInstance(FeatureContext context)
        {
            lock (SyncRoot)
            {
                if (context == null)
                {
                    _instance = null;
                    Initialized = false;
                }
                else
                {
                    _instance = context;
                    Initialized = true;
                }
            }
        }

        public static void Reset()
        {
            SetInstance(null);
        }

        private static void CheckInstance()
        {
            if (!Initialized)
            {
                throw new InvalidOperationException(SR.ErrorMessageFeatureContextNotInitialized);
            }
        }

        public static bool Initialized { get; private set; }
    }
}
