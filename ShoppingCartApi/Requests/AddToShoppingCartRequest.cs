namespace ShoppingCartApi.Requests
{
    public class AddToShoppingCartRequest
    {
        public string ProductId { get; set; }

        public int Amount { get; set; }
    }
}