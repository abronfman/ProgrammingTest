
using System;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;
using ProgrammingTest.Models;

namespace ProgrammingTest.Data
{
    public class XmlRepository
    {
        #region Private Fields

        private XmlSerializer _serializer;

        #endregion //Private Fields

        #region Properties

        //public XmlSerializer serializer {
        //    get { return _serializer ?? (_serializer = new XmlSerializer(typeof(T)))}
        //}

        #endregion //Properties

        /// <summary>
        /// Save an object to file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSave"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public void Save<T>(object objectToSave, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = $"pTest_{DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture)}.xml";
            }
            var serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream($"{fileName}.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    serializer.Serialize(fs, objectToSave);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        /// <summary>
        /// Find an object in a given file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public T Find<T>(string fileName) where T : BaseObject<T>
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return null;
            }
            var serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream($"{fileName}.xml", FileMode.Open))
            {
                return serializer.Deserialize(fs) as T;
            }
        }

        /// <summary>
        /// Delete an existing file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public void Delete(string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                try
                {
                    File.Delete($"{fileName}.xml");
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        /// <summary>
        /// Handle an exception 
        /// </summary>
        /// <param name="ex"></param>
        private void HandleException(Exception ex)
        {
            Console.Write($"Exception occured on file save: {ex.Message}");
        }
    }
}
