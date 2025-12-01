using BaciuAndreiLab7.Data;

namespace BaciuAndreiLab7;

public partial class App
{
    private static ShoppingListDatabase? _database;

    public App()
    {
        InitializeComponent();
    }

    public static ShoppingListDatabase Database
    {
        get
        {
            if (_database != null) return _database;
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "ShoppingList.db3");
            _database = new ShoppingListDatabase(dbPath);
            return _database;
        }
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}