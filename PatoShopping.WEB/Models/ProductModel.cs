using PatoShopping.API.Enum;

namespace PatoShopping.WEB.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public EnumCategory Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
