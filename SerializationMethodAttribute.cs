using System;
using System.Collections.Generic;
using System.Text;

namespace NHammock.Core
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter)]
    public class SerializationMethodAttribute : Attribute
    {
        public SerializationMethodAttribute(SerializationMethods method)
        {
            _method = method;
        }

        SerializationMethods _method;

        public SerializationMethods Method
        {
            get { return _method; }
            set { _method = value; }
        }
    }
}
