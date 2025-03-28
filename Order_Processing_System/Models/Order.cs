using System.ComponentModel.DataAnnotations;

namespace Order_Processing_System.Models
{
    // Order.cs
    public class Order
        {

            [Required(ErrorMessage = "At least one product must be selected.")]
            public int Id { get; set; }
            public List<Product> Products { get; set; }
            public decimal TotalPrice { get; set; }
            public DateTime OrderDate { get; set; } // New property for order date
        }
    
    
}
