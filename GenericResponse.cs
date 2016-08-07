using System;
using System.Collections.Generic;
using System.Text;

namespace NHammock.Core
{
    public class GenericResponse : ServiceCallResponseBase
    {
        public static GenericResponse Create(string message)
        {
            return new GenericResponse();
        }
    }
}
