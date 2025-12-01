using BaciuAndreiLab7.Models;

namespace BaciuAndreiLab7;

public partial class ProductPage : ContentPage
{
    private ShopList _currentShopList;

    public ProductPage(ShopList shopList)
    {
        InitializeComponent();
        _currentShopList = shopList;
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Product p;
        if (listView.SelectedItem != null)
        {
            p = (listView.SelectedItem as Product)!;
            var lp = new ListProduct()
            {
                ShopListID = _currentShopList.ID,
                ProductID = p.ID
            };
            await App.Database.SaveListProductAsync(lp);
            p.ListProducts = [lp];
            await Navigation.PopAsync();
        }
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var product = (Product)BindingContext;
        await App.Database.SaveProductAsync(product);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = listView.SelectedItem as Product;
        await App.Database.DeleteProductAsync(product);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
}