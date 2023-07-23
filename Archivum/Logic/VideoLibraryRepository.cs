using System.Collections.Generic;
using SQLite;

namespace Archivum.Logic;

public class VideoLibraryRepository
{
    public SQLiteAsyncConnection Database;
    public VideoLibraryRepository()
    {

    }
    public async Task Init()
    {
        if (Database is null)
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        _ = await Database.CreateTableAsync<VideoMaterial>();
    }

    public async Task<List<VideoMaterial>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<VideoMaterial>().ToListAsync();
    }

    public async Task<List<VideoMaterial>> GetItemsToListAsync(int start)
    {
        await Init();
        return await Database.QueryAsync<VideoMaterial>("SELECT * FROM [VideoMaterial] LIMIT " + start + ", " + 5);
    }

    public async Task<List<VideoMaterial>> GetItemsToListAsync(int start, string filter)
    {
        await Init();
        return await Database.QueryAsync<VideoMaterial>("SELECT * FROM [VideoMaterial] Where Type = '" + filter + "' LIMIT " + start + ", " + 5);

    }
    public async Task<VideoMaterial> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<VideoMaterial>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(VideoMaterial item)
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

    public async Task<int> DeleteItemAsync(VideoMaterial item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }

    public async Task<List<VideoMaterial>> GetSearchResults(string query)
    {
        await Init();
        return await Database.QueryAsync<VideoMaterial>("SELECT * FROM [VideoMaterial] Where Name LIKE '" + query+"'");
    }

    public async Task<int> GetCount(string query)
    {
        await Init();
        return await Database.Table<VideoMaterial>().CountAsync(i => i.Type == query);
    }

}
