
using System;

namespace ProgrammingTest.Data {
    /// <summary>
    /// Class responsible for creating an appropriate repository
    /// </summary>
    public static class RepositoryFactory {
        /// <summary>
        /// Create a Repository based on type provided
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IDataRepository CreateRepo(string type)
        {
            return (!string.IsNullOrWhiteSpace(type) && type.Equals("json", StringComparison.CurrentCultureIgnoreCase))
                ? new JsonRepository()
                : null;
        }
    }
}
