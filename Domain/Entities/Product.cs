using System.ComponentModel.DataAnnotations;

namespace BlazorCRUD.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Price  is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
    }
}
