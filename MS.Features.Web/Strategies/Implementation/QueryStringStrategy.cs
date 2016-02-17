using System;
using System.Linq;

namespace Rhenus.HD.Features.Strategies.Implementation
{
    public class QueryStringStrategy : StrategyReaderBase
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
                if (!queryString.AllKeys.Contains(key, StringComparer.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                return ConvertToBoolean(queryString[key]);
            }
            catch (Exception)
            {
                // TODO: logging extension point
                return false;
            }
        }
    }
}
