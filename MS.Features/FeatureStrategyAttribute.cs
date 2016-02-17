using System;

namespace Rhenus.HD.Features
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class FeatureStrategyAttribute : Attribute
    {
        public int Order { get; set; }

        public string Key { get; set; }

        protected FeatureStrategyAttribute()
        {
            Order = 0;
        }

        public ConfigurationContext BuildConfigurationContext()
        {
            return new ConfigurationContext(Key);
        }
    }
}
