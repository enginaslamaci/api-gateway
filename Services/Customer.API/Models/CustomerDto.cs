namespace Customer.API.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public static List<CustomerDto> GetCustomers()
        {
            var list = new List<CustomerDto>();
            list.Add(new CustomerDto() {Id = 1, Name = "customer1", Country = "TR", City = "İstanbul", Phone = "11111111111" });
            list.Add(new CustomerDto() {Id = 2, Name = "customer2", Country = "TR", City = "Kocaeli", Phone = "22222222222" });
            list.Add(new CustomerDto() {Id = 3, Name = "customer3", Country = "TR", City = "Ankara", Phone = "33333333333" });
            return list;
        }
    }
}
