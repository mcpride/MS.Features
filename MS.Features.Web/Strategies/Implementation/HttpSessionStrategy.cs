using System;
using Rhenus.HD.Features.Web;

namespace Rhenus.HD.Features.Strategies.Implementation
{
    public class HttpSessionStrategy : StrategyBase
    {
        public override bool Read()
        {
            return HttpContextFactory.Current.Session != null && ConvertToBoolean(HttpContextFactory.Current.Session[Context.Key]);
        }

        public override void Write(bool state)
        {
            var session = HttpContextFactory.Current.Session;
            if (session == null) throw new InvalidOperationException(SR.ErrorMessageHttpSessionNotAvailable);
            session[Context.Key] = state;
        }
    }
}
