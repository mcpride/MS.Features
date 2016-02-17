using System;
using System.Web;

namespace MS.Features
{
    public class HttpContextFactory
    {
        private static HttpContextBase _context;
        public static HttpContextBase Current
        {
            get
            {
                if (_context != null)
                {
                    return _context;
                }

                if (HttpContext.Current == null)
                {
                    throw new InvalidOperationException(Web.SR.ErrorMessageHttpContextNotAvailable);
                }

                return new HttpContextWrapper(HttpContext.Current);
            }
        }

        public static void SetCurrentContext(HttpContextBase context)
        {
            _context = context;
        }
    }
}
