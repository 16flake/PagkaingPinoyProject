using Microsoft.AspNetCore.Mvc;
using PagkaingPinoy.Interface;
using PagkaingPinoy.Models;
using PagkaingPinoy.ViewModel;

namespace PagkaingPinoy.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        //READ OPERATION
        public async Task<IActionResult> Index()
        {
            IEnumerable<Cart> cart = await _cartRepository.GetAll();
            return View(cart);
        }

        //UPDATE CONTROLLER
        public async Task<IActionResult> ModifyItem(int id)
        {
            var toModify = await _cartRepository.GetByIdAsync(id);
            if (toModify == null)
            {
                return View("Error");
            }

            var modifiedItem = new CartViewModel
            {
                DishName = toModify.DishName,
                Price = toModify.Price,
                Quantity = toModify.Quantity,
                Subtotal = toModify.Price * toModify.Quantity
            };

            return View(modifiedItem);
        }

        //UPDATE OPERATION
        [HttpPost]
        public IActionResult ModifyItem(int id, CartViewModel cartVM)
        {
            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError("", "Failed to modify.");
                return View("ModifyItem", cartVM);
            }

            var newItem = new Cart
            {
                Id = id,
                DishName = cartVM.DishName,
                Price = cartVM.Price,
                Quantity = cartVM.Quantity,
                Subtotal = cartVM.Price * cartVM.Quantity
            };

            _cartRepository.Update(newItem);
            return RedirectToAction("Index");
        }

        //DELETE CONTROLLER
        public async Task<IActionResult> DeleteItem(int id)
        {
            var toDelete = await _cartRepository.GetByIdAsync(id);
            if (toDelete == null)
            {
                return View("Error");
            }

            return View(toDelete);
        }

        //DELETE OPERATION
        [HttpPost, ActionName("DeleteItem")]
        public async Task<IActionResult> DeletedItem(int id)
        {
            var toDelete = await _cartRepository.GetByIdAsync(id);
            if (toDelete == null)
            {
                return View("Error");
            }

            _cartRepository.Delete(toDelete);
            return RedirectToAction("Index");
        }
    }
}
