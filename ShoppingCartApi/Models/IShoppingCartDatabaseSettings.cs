namespace ShoppingCartApi.Models
{
    public interface IShoppingCartDatabaseSettings
    {
        string ProductCollectionName { get; set; }
        string ShoppingCartCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}