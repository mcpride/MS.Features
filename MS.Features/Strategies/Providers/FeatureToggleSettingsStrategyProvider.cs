using MS.Features.Configuration;

namespace MS.Features.Strategies.Providers
{
    public class FeatureToggleSettingsStrategyProvider : StrategyReaderBase
    {
        public override bool Read()
        {
            var instance = FeatureToggleSettings.Instance;
            if (instance == null) return false;
            var features = instance.Features;
            if (features == null) return false;
            var feature = features[Context.Key];
            return ((feature != null) && feature.Enabled);
        }
    }
}
