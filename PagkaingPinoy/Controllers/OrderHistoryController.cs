using Microsoft.AspNetCore.Mvc;
using PagkaingPinoy.Interface;
using PagkaingPinoy.Models;

namespace PagkaingPinoy.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly IOrderHistoryRepository _orderHistoryRepository;

        public OrderHistoryController(IOrderHistoryRepository orderHistoryRepository)
        {
            _orderHistoryRepository = orderHistoryRepository;
        }

        //READ CONTROLLER | DISPLAY MENU FOR ORDERING
        public async Task<IActionResult> Index()
        {
            IEnumerable<OrderHistory> orderHistory = await _orderHistoryRepository.GetAll();
            return View(orderHistory);
        }
    }
}
