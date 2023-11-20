
using SQLite;

namespace Archivum.Logic
{
    public interface IRepository
    {
        SQLiteAsyncConnection Database { get; set; }
        Task Init<T>() where T : new();
        Task<List<T>> GetItemsAsync<T>() where T : new();
        Task<List<T>> ExecuteRequest<T>(string query) where T : new();
        Task<int> ExecuteScalar<T>(string query) where T : new();
        Task<int> DeleteItemAsync<T>(T item) where T : new();
        Task<int> SaveItemAsync<T>(T item, int Id) where T : new();
        Task<int> GetCount<T>() where T : new();
        Task<T> GetItemAsync<T>(int iD) where T: IModel, new();
    }
}
