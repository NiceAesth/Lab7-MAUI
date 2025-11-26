using BaciuAndreiLab7.Models;
using SQLite;

namespace BaciuAndreiLab7.Data;

public class ShoppingListDatabase
{
    private readonly SQLiteAsyncConnection _database;
    
    public ShoppingListDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<ShopList>().Wait();
    }
    
    public Task<List<ShopList>> GetAllAsync()
    {
        return _database.Table<ShopList>().ToListAsync();
    }

    public Task<ShopList> GetByIdAsync(int id)
    {
        return _database.Table<ShopList>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
    }
    
    public Task<int> SaveAsync(ShopList shopList)
    {
        return shopList.ID != 0 ? _database.UpdateAsync(shopList) : _database.InsertAsync(shopList);
    }

    public Task<int> DeleteAsync(ShopList shopList)
    {
        return _database.DeleteAsync(shopList);
    }
}