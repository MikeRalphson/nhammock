using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace NHammock.Core
{
    public abstract class ServiceCallResponseBase : ServiceMessageBase
    {
        public ServiceCallResponseBase()
            : this(true, null)
        { 
        }

        public ServiceCallResponseBase(bool success, string errorMessage)
        {
            Initialise(success, errorMessage);
        }

        bool _success;

        [XmlElement("Success")]
        public bool Success
        {
            get { return _success; }
            set { _success = value; }
        }

        string _errorMessage;

        [XmlElement("ErrorMessage")]
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public void Initialise(bool success, string errorMessage)
        {
            _success = success;
            _errorMessage = errorMessage;
        }
    }
}
