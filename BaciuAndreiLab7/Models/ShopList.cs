using SQLite;

namespace BaciuAndreiLab7.Models;

public class ShopList
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    [MaxLength(250), Unique]
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}