using System;
using System.Configuration;
using System.Web;

namespace NHammock.Core
{
    public class HealthCheckResponse : ServiceCallResponseBase
    {
        public HealthCheckResponse()
            : base(true, null)
        {
        }

        internal static HealthCheckResponse Create()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
