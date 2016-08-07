using System;
using System.Collections.Generic;
using System.Text;

namespace NHammock.Core
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RequiredHttpVerbAttribute : Attribute
    {
        public RequiredHttpVerbAttribute(HttpVerbs verb)
        {
            _verb = verb;
        }

        HttpVerbs _verb;

        public HttpVerbs Verb
        {
            get { return _verb; }
            set { _verb = value; }
        }
    }
}
