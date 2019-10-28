using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace TxTimeSynchro
{
    public static class Util
    {

        /// <summary>
        /// Deserialize object from xml, which was serilized by [Serializable] flag.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="extraTypes">The extra types.</param>
        /// <param name="xml">XML data.</param>
        /// <returns>Deserialized object.</returns>
        public static object DeserializeObjectFromXml(Type resultType, Type[] extraTypes, string xml)
        {
            if (xml == null || xml.Length == 0) return null;

            object result;
            XmlSerializer serializer = new XmlSerializer(resultType, extraTypes);
            TextReader r = new StringReader(xml);
            result = serializer.Deserialize(r);

            return result;
        }

        /// <summary>
        /// Create XML from specified object by serialization.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="extraTypes">The extra types.</param>
        /// <param name="obj">The obj.</param>
        /// <returns>XML data.</returns>
        public static string SerializeObjectToXml(Type objectType, Type[] extraTypes, object obj)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(objectType, extraTypes);
            TextWriter w = new StringWriter(sb);
            serializer.Serialize(w, obj);
            w.Flush();
            w.Close();

            return sb.ToString();
        }

        #region static

        public static string ExtractResourceFile(string resourceFileName)
        {
            string result = string.Empty;

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Stream stream = assembly.GetManifestResourceStream(resourceFileName);
                if (stream != null)
                {
                    using (stream)
                    {
                        var sr = new StreamReader(stream);
                        result = sr.ReadToEnd();
                        sr.Close();
                    }

                    break;
                }
            }

            return result;
        }

        #endregion
    }
}