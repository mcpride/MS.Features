using System.Configuration;

namespace Rhenus.HD.Features.Strategies.Implementation
{
    public class AppSettingsStrategy : StrategyReaderBase
    {
        public override bool Read()
        {
            var value = ConfigurationManager.AppSettings[Context.Key];
            return ConvertToBoolean(value);
        }
    }
}
