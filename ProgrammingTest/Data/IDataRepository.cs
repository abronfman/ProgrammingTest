
using ProgrammingTest.Models;

namespace ProgrammingTest.Data {
    public interface IDataRepository
    {
        void Save<T>(object objectToSave) where T: BaseObject<T>;
        T Find<T>(string id) where T : BaseObject<T>;
        void Delete(string id);

    }
}
