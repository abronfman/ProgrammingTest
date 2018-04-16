
using System;
using System.IO;
using System.Net.Mime;
using System.Runtime.Remoting.Channels;
using Newtonsoft.Json;
using ProgrammingTest.Models;

namespace ProgrammingTest.Data {
    /// <summary>
    /// Class the defines CRUD operations for reading/writing json files
    /// </summary>
    public class JsonRepository : IDataRepository {
        /// <summary>
        /// Save an object to file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSave"></param>
        /// <returns></returns>
        public void Save<T>(object objectToSave) where T : BaseObject<T>
        {

            if (objectToSave == default(object) || !(objectToSave is BaseObject<T>))
            {
                return;
            }
            var path = SetFilePath(((BaseObject<T>)objectToSave).Id);
            try
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(objectToSave));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Find an object for a given id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(string id) where T : BaseObject<T>
        {
            var path = SetFilePath(id);
            if (!File.Exists(path))
            {
                return null;
            }
            string text = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(text);
        }

        /// <summary>
        /// Delete an existing object
        /// </summary>
        /// <param name="id"></param>
        public void Delete(string id)
        {
            var path = SetFilePath(id);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        #region Helper Methods
        /// <summary>
        /// Create a file path for the given object id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectId"></param>
        /// <returns></returns>
        private string SetFilePath(string objectId)
        {
            var fileName = $"{objectId}.json";
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        #endregion //Helper Methods
    }
}
