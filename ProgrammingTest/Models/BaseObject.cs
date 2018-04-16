

using System;
using System.Xml.Linq;
using ProgrammingTest.Data;

namespace ProgrammingTest.Models
{
    /// <summary>
    /// Base class to define default behavior
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseObject<T>
        where T : BaseObject<T>
    {

        #region Properties
        public string Id { get; set; }
        public static  IDataRepository Repo { get; set; }

        #endregion //Properties

        #region Constructors
        /// <summary>
        /// Create a new instance of <see cref="BaseObject{T}"/>
        /// </summary>
        protected BaseObject()
        {
            Repo = RepositoryFactory.CreateRepo("json");
        }
        #endregion //Constructors

        #region CRUD Operations

        /// <summary>
        /// Find an object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T Find(string id)
        {
            return string.IsNullOrWhiteSpace(id) ? null : Repo.Find<T>(id);
        }

        /// <summary>
        /// Save an object to file
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            Id = string.IsNullOrWhiteSpace(Id) ? Guid.NewGuid().ToString() : Id;
            Repo.Save<T>(this);
        }

        public void Delete()
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                return;
            }
            Repo.Delete(Id);
            Id = string.Empty;
        }
        #endregion //CRUD Operations
    }
}
