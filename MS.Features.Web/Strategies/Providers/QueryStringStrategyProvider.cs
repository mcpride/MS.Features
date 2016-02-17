using System;
using System.Linq;

namespace MS.Features.Strategies.Providers
{
    public class QueryStringStrategyProvider : StrategyReaderBase
    {
        public override bool Read()
        {
            var key = Context.Key;

            try
            {
                if (HttpContextFactory.Current.Request == null)
                {
                    return false;
                }

                if (HttpContextFactory.Current.Request.QueryString == null)
                {
                    return false;
                }

                var queryString = HttpContextFactory.Current.Request.QueryString;
                return queryString.AllKeys.Contains(key, StringComparer.InvariantCultureIgnoreCase) && ConvertToBoolean(queryString[key]);
            }
            catch (Exception)
            {
                // TODO: logging extension point
                return false;
            }
        }
    }
}
