# AddProductToShoppingCartApi
Çalıştırılması için gerekenler:
.net core 3.1
MongoDb

Ürün listelemenin olduğunun varsayılması istenmiş fakat ben testlerimde kullanabilmek için bir endpoint yazdım. Endpoint lere aşağıdaki şekilde istek gönderilebilir.

GET https://localhost:5001/api/shoppingCart sepetteki ürünleri listeler
POST https://localhost:5001/api/shoppingCart sepete ürün ekler. Post metodu için request aşağıdaki json formatında olmalıdır. productId, eklenecek ürünün id sini, amount ise adedini temsil ediyor.
{
    "productId": "5f1cb2bdfb5c096adc143b04",
    "amount": 1
}


 {
    "Id": "5f1cb2bdfb5c096adc143b04",
    "Name": "Rose",
    "Price": 15.2,
    "AvailableQuantity": 10
}


Projeyi geliştirirken NoSql teknolojisi olan MongoDb kullanmak istedim. Daha önce kullanmamıştım benim için de challange oldu :) 
