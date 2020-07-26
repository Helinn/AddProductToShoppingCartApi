namespace ShoppingCartApi.Models
{
    public class ShoppingCartDatabaseSettings : IShoppingCartDatabaseSettings
    {
        public ShoppingCartDatabaseSettings()
        {
        }

        public string ProductCollectionName { get; set; }

        public string ShoppingCartCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}