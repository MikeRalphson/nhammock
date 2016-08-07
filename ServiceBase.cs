using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace NHammock.Core
{
    // base class for *.ashx in this project
    public class HammockServiceBase
    {
        protected bool CheckHttpMethod(string method)
        {
            HttpContext context = HttpContext.Current;
            return string.Equals(method, context.Request.HttpMethod, StringComparison.InvariantCultureIgnoreCase);
        }

        protected virtual void DoHealthCheck(HttpContext context)
        {
            context.Response.Write(new HealthCheckResponse().Serialize());
        }

        protected string ReadHttpBody(HttpContext context)
        {
            using (StreamReader reader = new StreamReader(context.Request.InputStream))
            {
                return reader.ReadToEnd();
            }
        }

        protected void WriteResult<T>(HttpContext context, T result) where T : ServiceMessageBase
        {
            if (result != null)
            {
                context.Response.Write(result.Serialize());
            }
        }

        protected virtual GenericResponse OnMissingMethodCall()
        {
            return GenericResponse.Create("Invalid service method");
        }

        protected virtual GenericResponse OnInvalidHttpVerb(string verb, string method)
        {
            return GenericResponse.Create("Invalid HTTP verb");
        }
    }
}
