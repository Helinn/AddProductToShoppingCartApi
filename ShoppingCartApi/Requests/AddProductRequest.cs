namespace ShoppingCartApi.Requests
{
    public class AddProductRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}