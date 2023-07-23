using SQLite;

namespace Archivum.Logic
{
    internal class TextLibraryRepository
    {
        public SQLiteAsyncConnection Database;
        public TextLibraryRepository()
        {

        }
        public async Task Init()
        {
            if (Database is null)
            {
                Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            }

            var result = await Database.CreateTableAsync<TextMaterial>();
        }

        public async Task<List<TextMaterial>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<TextMaterial>().ToListAsync();
        }

        public async Task<TextMaterial> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<TextMaterial>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<List<TextMaterial>> GetItemsToListAsync(int start)
        {
            await Init();
            return await Database.QueryAsync<TextMaterial>("SELECT * FROM [TextMaterial] LIMIT " + start + ", " + 5);

        }
        public async Task<List<TextMaterial>> GetItemsToListAsync(int start, string filter)
        {
            await Init();
            return await Database.QueryAsync<TextMaterial>("SELECT * FROM [TextMaterial] Where Type = '" + filter + "' LIMIT " + start + ", " + 5);

        }
        public async Task<int> SaveItemAsync(TextMaterial item)
        {
            await Init();
            if (item.ID != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(TextMaterial item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }

        public async Task<List<TextMaterial>> GetSearchResults(string query)
        {
            await Init();
            return await Database.QueryAsync<TextMaterial>("SELECT * FROM [TextMaterial] Where Name LIKE '" + query + "'");
        }

        public async Task<int> GetCount(string query)
        {
            await Init();
            return await Database.Table<TextMaterial>().CountAsync(i => i.Type == query);
        }

    }
}
