using Order_Processing_System.Models;
using Order_Processing_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Order_Processing_System.Services
{
    public class OrderService : IOrderService
    {
        private static List<Order> _orders = new List<Order>(); // In-memory list for orders
        private readonly IProductRepository _productRepository;

        public OrderService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void PlaceOrder(Order order)
        {
            if (order.Products == null || !order.Products.Any())
            {
                throw new ArgumentException("Order must have at least one product.");
            }

            order.TotalPrice = order.Products.Sum(p => p.Price);
            order.Id = _orders.Count + 1; // Generate a simple unique ID
            order.OrderDate = DateTime.UtcNow; // Set the order date to the current date and time
            _orders.Add(order); // Add the order to the in-memory list
        }

        public Order GetOrderById(int orderId)
        {
            return _orders.FirstOrDefault(o => o.Id == orderId); // Retrieve the order by ID
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orders; // Return the list of orders
        }
    }
}