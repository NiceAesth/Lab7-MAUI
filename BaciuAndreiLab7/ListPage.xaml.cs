using BaciuAndreiLab7.Models;

namespace BaciuAndreiLab7;

public partial class ListPage
{
    public ListPage()
    {
        InitializeComponent();
    }

    private async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ShopList)
            BindingContext)
        {
            BindingContext = new Product()
        });
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var shopList = (ShopList)BindingContext;
        shopList.Date = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(shopList);
        await Navigation.PopAsync();
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var shopList = (ShopList)BindingContext;
        await App.Database.DeleteShopListAsync(shopList);
        await Navigation.PopAsync();
    }
    
    private async void OnDeleteProductButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var listProduct = (ListProduct)button.CommandParameter;
        await App.Database.DeleteListProductAsync(listProduct);
        var shopList = (ShopList)BindingContext;
        ListView.ItemsSource = await App.Database.GetListProductAsync(shopList.ID);
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopList = (ShopList)BindingContext;
        ListView.ItemsSource = await App.Database.GetListProductAsync(shopList.ID);
    }
}