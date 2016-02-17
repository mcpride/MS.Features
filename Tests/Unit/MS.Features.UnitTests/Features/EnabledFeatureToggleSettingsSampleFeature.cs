using MS.Features.Strategies.Configuration;

namespace MS.Features.UnitTests.Features
{
    [FeatureToggleSettingsStrategy(Key = "EnabledSampleFeature")]
    public class EnabledFeatureToggleSettingsSampleFeature : FeatureBase
    {
    }
}
