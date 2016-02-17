using MS.Features.Strategies.Configuration;

namespace MS.Features.UnitTests.Features
{
    [FeatureToggleSettingsStrategy(Key = "DisabledSampleFeature")]
    public class DisabledFeatureToggleSettingsSampleFeature : FeatureBase
    {
    }
}
