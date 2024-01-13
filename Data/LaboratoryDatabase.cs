using SQLite;
using TodoSQLite.Models;

namespace TodoSQLite.Data;

public class LaborotoryDatabase
{
    SQLiteAsyncConnection Database;
    public LaborotoryDatabase()
    {
    }
    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<Laboratory>();
    }

    public async Task<List<Laboratory>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<Laboratory>().ToListAsync();
    }

    public async Task<List<Laboratory>> GetItemsNotDoneAsync()
    {
        await Init();
        return await Database.Table<Laboratory>().Where(t => t.IsWorking).ToListAsync();
        
        // SQL queries are also possible
        //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
    }

    public async Task<Laboratory> GetItemAsync(int id)
    {
        await Init();
        return await Database.Table<Laboratory>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveItemAsync(Laboratory item)
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

    public async Task<int> DeleteItemAsync(Laboratory item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }
}