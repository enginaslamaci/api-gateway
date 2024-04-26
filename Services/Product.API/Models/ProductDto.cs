namespace Product.API.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }

        public static List<ProductDto> GetProducts()
        {
            var list = new List<ProductDto>();
            list.Add(new ProductDto() { Id = 1, Name = "product1", Code = "111", UnitPrice = 1000, Stock = 3000, ImageUrl = "https://picsum.photos/300/200" });
            list.Add(new ProductDto() { Id = 2, Name = "product2", Code = "222", UnitPrice = 1500, Stock = 3500, ImageUrl = "https://picsum.photos/300/200" });
            list.Add(new ProductDto() { Id = 3, Name = "product3", Code = "333", UnitPrice = 2000, Stock = 4500, ImageUrl = "https://picsum.photos/300/200" });
            return list;
        }
    }
}
