using Order_Processing_System.Models;

namespace Order_Processing_System.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = " Chicken Sandwich", Price = 22 },
        new Product { Id = 2, Name = "Coca Cola", Price = 15 },
        new Product { Id = 3, Name = "Vanilla Muffin", Price = 10 },
        new Product { Id = 4, Name = "Orange Juice", Price = 15 },
        new Product { Id = 5, Name = "Fries", Price = 17 },
        new Product { Id = 6, Name = "Cheese & Tomatoe Sandwich", Price = 20 },
        new Product { Id = 7, Name = "ChocChip Cookie", Price = 6 },
        new Product { Id = 8, Name = "Iced Tea", Price = 11 },
        new Product { Id = 9, Name = "Chocolate Milkshake", Price = 21 },
        new Product { Id = 10, Name = "Chicken Wrap", Price = 25 },
        new Product { Id = 11, Name = "Coffee", Price = 15 },
        new Product { Id = 12, Name = "Chai Tea", Price = 13 }
    };

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }
    }
}
