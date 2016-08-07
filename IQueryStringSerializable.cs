using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace NHammock.Core
{
    public interface IQueryStringSerializable
    {
        string SerializeToQueryString();

        void DeserializeFromQueryString(NameValueCollection queryString);
    }
}
