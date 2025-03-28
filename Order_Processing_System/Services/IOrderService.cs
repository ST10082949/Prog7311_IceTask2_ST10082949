using Microsoft.AspNetCore.Mvc;
using Order_Processing_System.Models;

namespace Order_Processing_System.Services
{
    public interface IOrderService
    {
        void PlaceOrder(Order order);
        Order GetOrderById(int orderId); // Add this method
        IEnumerable<Order> GetAllOrders(); // Add this line
    }
}
