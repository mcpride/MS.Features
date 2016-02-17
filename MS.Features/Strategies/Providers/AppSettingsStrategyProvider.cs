using System.Configuration;

namespace MS.Features.Strategies.Providers
{
    public class AppSettingsStrategyProvider : StrategyReaderBase
    {
        public override bool Read()
        {
            var value = ConfigurationManager.AppSettings[Context.Key];
            return ConvertToBoolean(value);
        }
    }
}
