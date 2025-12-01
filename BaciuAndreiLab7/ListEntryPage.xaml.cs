using BaciuAndreiLab7.Models;

namespace BaciuAndreiLab7;

public partial class ListEntryPage
{
    public ListEntryPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ListView.ItemsSource = await App.Database.GetShopListsAsync();
    }

    private async void OnShoppingListAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPage
        {
            BindingContext = new ShopList()
        });
    }

    private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        await Navigation.PushAsync(new ListPage
        {
            BindingContext = e.SelectedItem as ShopList
        });
    }
}