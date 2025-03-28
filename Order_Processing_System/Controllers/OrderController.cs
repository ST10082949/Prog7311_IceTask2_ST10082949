using Microsoft.AspNetCore.Mvc;
using Order_Processing_System.Models;
using Order_Processing_System.Repositories;
using Order_Processing_System.Services;

namespace Order_Processing_System.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderService _orderService;

        public OrderController(IProductRepository productRepository, IOrderService orderService)
        {
            _productRepository = productRepository;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }

        [HttpPost]
        public IActionResult PlaceOrder(IEnumerable<int> Products)
        {
            if (Products == null || !Products.Any())
            {
                ModelState.AddModelError(string.Empty, "Please select at least one product.");
                return View("Index", _productRepository.GetAllProducts());
            }

            // Create order instance
            var selectedProducts = Products.Select(id => _productRepository.GetAllProducts().FirstOrDefault(p => p.Id == id)).ToList();
            var totalPrice = selectedProducts.Sum(p => p.Price);

            var order = new Order
            {
                Products = selectedProducts,
                TotalPrice = totalPrice

            };

            // Here you might want to save the order in memory or in a list if you want to display later
            _orderService.PlaceOrder(order); // Store order in the service

            return RedirectToAction("OrderConfirmation", new { orderId = order.Id }); // assuming Order has an Id property
        }

        public IActionResult OrderConfirmation(int orderId)
        {
            var order = _orderService.GetOrderById(orderId); // Implement this method in OrderService
            return View(order); // Pass the order to the view
        }

        public IActionResult PreviousOrders()
        {
            var orders = _orderService.GetAllOrders(); // Retrieve all orders
            return View(orders); // Pass the orders to the view
        }
    }
}
