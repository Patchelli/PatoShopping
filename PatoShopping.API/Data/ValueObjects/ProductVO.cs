using PatoShopping.API.Enum;
using System.ComponentModel.DataAnnotations;

namespace PatoShopping.API.Data.ValueObjects
{
    public class ProductVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public EnumCategory Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
