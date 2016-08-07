using System;
using System.Collections.Generic;
using System.Text;

namespace NHammock.Core
{
    public abstract class ServiceMessageBase
    {
        public string Serialize()
        {
            return Serializer.Serialize(this);
        }
    }
}
