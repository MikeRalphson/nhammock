using System;
using System.Collections.Generic;
using System.Text;
using NHammock.Core.Samples;

namespace NHammock.Core.Samples
{
    public class ExemplarService : HammockServiceBase
    {
        [RequiredHttpVerb(HttpVerbs.Get)]
        public HealthCheckResponse HealthCheck()
        {
            return HealthCheckResponse.Create();
        }

        [RequiredHttpVerb(HttpVerbs.Put)]
        public CreateUserResponse CreateUser([SerializationMethod(SerializationMethods.Xml)] CreateUserRequest request)
        {
            return CreateUserResponse.Create();
        }

        [RequiredHttpVerb(HttpVerbs.Post)]
        public UpdateUserResponse UpdateUser([SerializationMethod(SerializationMethods.Json)] UpdateUserRequest request)
        {
            return UpdateUserResponse.Create();
        }

        [RequiredHttpVerb(HttpVerbs.Get)]
        [SerializationMethod(SerializationMethods.Json)]
        public GetUserResponse GetUser([SerializationMethod(SerializationMethods.QueryString)] GetUserRequest request)
        {
            return GetUserResponse.Create();
        }

        protected override GenericResponse OnMissingMethodCall()
        {
            return GenericResponse.Create("Custom message");
        }

        protected override GenericResponse OnInvalidHttpVerb(string verb, string method)
        {
            return GenericResponse.Create("Custom message");
        }
    }
}
