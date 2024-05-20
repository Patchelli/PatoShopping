using PatoShopping.API.Enum;
using PatoShopping.API.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace PatoShopping.API.Model
{

    public class Product : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        [Required]
        public EnumCategory Category { get; set; }
        [Required]
        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
