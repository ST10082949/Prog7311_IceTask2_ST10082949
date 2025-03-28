using Order_Processing_System.Models;

namespace Order_Processing_System.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
    }
}
