namespace ShoppingCartApi.Models
{
    public class ShoppingCartDatabaseSettings : IShoppingCartDatabaseSettings
    {
        public ShoppingCartDatabaseSettings()
        {
        }

        public ShoppingCartDatabaseSettings(string connectionString, string databaseName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
            ProductCollectionName = "Product";
            ShoppingCartCollectionName = "ShoppingCart";
        }
        public string ProductCollectionName { get; set; }

        public string ShoppingCartCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}