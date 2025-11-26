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
        ListView.ItemsSource = await App.Database.GetAllAsync();
    }
    
    async void OnShoppingListAddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPage
        {
            BindingContext = new Models.ShopList()
        });
    }

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        await Navigation.PushAsync(new ListPage
        {
            BindingContext = e.SelectedItem as Models.ShopList
        });
    }
}