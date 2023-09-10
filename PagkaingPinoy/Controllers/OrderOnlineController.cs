using Microsoft.AspNetCore.Mvc;
using PagkaingPinoy.Data;
using PagkaingPinoy.Interface;
using PagkaingPinoy.Models;
using PagkaingPinoy.ViewModel;

namespace PagkaingPinoy.Controllers
{

    //MAIN CONTROLLER FOR ORDERING
    public class OrderOnlineController : Controller
    {
        //GET ALL THE REPOSITORY FOR WORKING ON DATA BASE
        private readonly IMenuRepository _menuRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IOrderHistoryRepository _orderHistoryRepository;

        public OrderOnlineController(IMenuRepository menuRepository, ICartRepository cartRepository, IOrderHistoryRepository orderHistoryRepository)
        {
            _menuRepository = menuRepository;
            _cartRepository = cartRepository;
            _orderHistoryRepository = orderHistoryRepository;
        }

        //READ AND DISPLAY MENU LIST FROM MENU MODEL
        public async Task<IActionResult> Index()
        {
            IEnumerable<Menu> menus = await _menuRepository.GetAll();
            return View(menus);
        }

        //CREATE CONTROLLER | ADD TO CART
        public async Task<IActionResult> AddToCart(int id)
        {
            var item = await _menuRepository.GetByIdAsync(id);
            if (item == null)
            {
                return View("Error");
            }

            var itemVM = new CartViewModel
            {
                DishName = item.DishName,
                Price = item.Price,
                Quantity = 1
            };

            return View(itemVM);
        }

        //CREATE OPERATION FOR ADDING ORDERS TO THE CART
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, CartViewModel itemVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to add this to your cart.");
                return View("AddToCart", itemVM);
            }

            //Get the list of items inside the cart to check if the items being add already exist
            IEnumerable<Cart> inCart = await _cartRepository.GetAll();
            int itemId = 0;
            int quantity = itemVM.Quantity;

            //If the current item being add to the cart exist, get the ID.
            foreach (var item in inCart)
            {
                //if item exist, get the current value (Quantity and Id)
                if (itemVM.DishName == item.DishName)
                {
                    itemId = itemId + item.Id;
                    quantity = quantity + item.Quantity; //Add the current quantity to the new quantity value
                    break
;                }
            }

            //If id is 0, the item being added do not exist.
            if(itemId == 0)
            {
                var newItem = new Cart
                {
                    DishName = itemVM.DishName,
                    Price = itemVM.Price,
                    Quantity = itemVM.Quantity,
                    Subtotal = itemVM.Price * itemVM.Quantity
                };

                _cartRepository.Add(newItem);
            }

            //If id is not 0, the item already exist.
            else
            {
                //Add the new item with the item details (quantity) from the previous item
                var newItem = new Cart
                {
                    DishName = itemVM.DishName,
                    Price = itemVM.Price,
                    Quantity = quantity,
                    Subtotal = itemVM.Price * quantity
                };

                _cartRepository.Add(newItem);

                //Get the details of the previous item details and delete to to avoid duplication
                var prevItem = await _cartRepository.GetByIdAsync(itemId);
                _cartRepository.Delete(prevItem);
            }

            return RedirectToAction("Index", "OrderOnline");
        }

        //CREATE CONTROLLER | CHECKOUT
        public async Task<IActionResult> CheckOut()
        {
            IEnumerable<Cart> inCart = await _cartRepository.GetAll();
            if (inCart == null)
            {
                return View("Error");
            }

            int numberOfItems = 0;
            int total = 0;
            foreach(var item in inCart)
            {
                numberOfItems = numberOfItems + item.Quantity; //Get total number of items in the cart
                total = total + item.Subtotal; //Compute the total amount payable for all the items in the cart
            }

            var orderVM = new OrderHistoryViewModel //Create temporary model container inside the ViewModel
            {
                OrderDetail = numberOfItems,
                Total = total
            };

            return View(orderVM); //Display the checkout details through ViewModel
        }

        //CREATE OPERATION | CHECKOUT
        [HttpPost]
        public async Task<IActionResult> CheckOut(OrderHistoryViewModel orderVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to checkout.");
                return View("CheckOut", orderVM);
            }

            var newOrder = new OrderHistory //Create new order history
            {
                //Transaction Id and Transaction Date auto created through the Model
                NumberOfItems = orderVM.OrderDetail,
                Total = orderVM.Total
            };

            _orderHistoryRepository.Add(newOrder); //Store the data in the database

            //When checkout is successful, clear the cart.
            var clearCart = await _cartRepository.GetAll();
            foreach(var inCart in clearCart)
            {
                var item = await _cartRepository.GetByIdAsync(inCart.Id);
                _cartRepository.Delete(item);
            }

            return RedirectToAction("Index", "OrderOnline");
        } 
    }
}
