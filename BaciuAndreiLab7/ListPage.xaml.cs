namespace BaciuAndreiLab7;

public partial class ListPage
{
    public ListPage()
    {
        InitializeComponent();
    }
    
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var shopList = (Models.ShopList)BindingContext;
        shopList.Date = DateTime.UtcNow;
        await App.Database.SaveAsync(shopList);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var shopList = (Models.ShopList)BindingContext;
        await App.Database.DeleteAsync(shopList);
        await Navigation.PopAsync();
    }
}