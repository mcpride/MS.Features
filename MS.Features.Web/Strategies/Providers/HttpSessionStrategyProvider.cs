using System;

namespace MS.Features.Strategies.Providers
{
    public class HttpSessionStrategyProvider : StrategyBase
    {
        public override bool Read()
        {
            return HttpContextFactory.Current.Session != null && ConvertToBoolean(HttpContextFactory.Current.Session[Context.Key]);
        }

        public override void Write(bool state)
        {
            var session = HttpContextFactory.Current.Session;
            if (session == null) throw new InvalidOperationException(Web.SR.ErrorMessageHttpSessionNotAvailable);
            session[Context.Key] = state;
        }
    }
}
