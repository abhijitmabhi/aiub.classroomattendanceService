using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AIUB.FingerPrintSync.Framework.Helpers.AppSettings
{
    internal class ObjecSerializer:IDisposable
    {
        /// <summary>
        /// Serializes an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializableObject"></param>
        /// <param name="fullFilePath"></param>
        /// <param name="error"></param>
        internal bool SerializeObject<T>(T serializableObject, string fullFilePath, out string message)
        {
            message = string.Empty;
            if (serializableObject == null) { return
                false;
            }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fullFilePath);
                    stream.Close();
                }
                message = "Operation successfull";
                return true;
            }
            catch (Exception ex)
            {
                message = message = "Exception occurred! " + ex.ToString();
                //Log exception here
                return false;
            }
        }


        /// <summary>
        /// Deserializes an xml file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullFilePath"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        internal T DeSerializeObject<T>(string fullFilePath, out string message)
        {
            message = string.Empty;
            if (string.IsNullOrEmpty(fullFilePath)) { return default(T); }

            T objectOut = default(T);

            try
            {
                string attributeXml = string.Empty;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fullFilePath);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                    message = "Operation successfull";
                }
            }
            catch (Exception ex)
            {
                message = "Exception occurred! " + ex.ToString();
                //Log exception here
            }

            return objectOut;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
