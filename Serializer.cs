using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace NHammock.Core
{
    public static class Serializer
    {
        public static T Deserialize<T>(string serializedObject)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader sr = new StringReader(serializedObject);
            return (T)serializer.Deserialize(sr);
        }

        public static string Serialize(object obj)
        {
            if (obj == null)
                return string.Empty;

            //NB: this forces the output to be written as UTF-8, not the default UTF-16
            using (StringWriter writer = new Utf8StringWriter())
            {
                XmlFragmentWriter xfw = new XmlFragmentWriter(writer);
                xfw.Formatting = Formatting.Indented;

                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(xfw, obj);

                return writer.GetStringBuilder().ToString();
            }
        }
    }
}
