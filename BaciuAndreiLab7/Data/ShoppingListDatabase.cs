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
        _database.CreateTableAsync<Product>().Wait();
        _database.CreateTableAsync<ListProduct>().Wait();
    }

    public Task<List<Product>> GetProductsAsync()
    {
        return _database.Table<Product>().ToListAsync();
    }

    public Task<List<ListProduct>> GetListProductAsync(int shopListId)
    {
        return _database.Table<ListProduct>()
            .Where(lp => lp.ShopListID == shopListId)
            .ToListAsync();
    }

    public Task<int> SaveProductAsync(Product product)
    {
        return product.ID != 0 ? _database.UpdateAsync(product) : _database.InsertAsync(product);
    }

    public Task<int> SaveListProductAsync(ListProduct listProduct)
    {
        return listProduct.ID != 0 ? _database.UpdateAsync(listProduct) : _database.InsertAsync(listProduct);
    }

    public Task<int> DeleteProductAsync(Product product)
    {
        return _database.DeleteAsync(product);
    }

    public Task<List<ShopList>> GetShopListsAsync()
    {
        return _database.Table<ShopList>().ToListAsync();
    }

    public Task<ShopList> GetShopListAsync(int id)
    {
        return _database.Table<ShopList>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
    }

    public Task<int> SaveShopListAsync(ShopList shopList)
    {
        return shopList.ID != 0 ? _database.UpdateAsync(shopList) : _database.InsertAsync(shopList);
    }

    public Task<int> DeleteShopListAsync(ShopList shopList)
    {
        return _database.DeleteAsync(shopList);
    }
}