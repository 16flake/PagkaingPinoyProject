using Microsoft.AspNetCore.Mvc;
using PagkaingPinoy.Interface;
using PagkaingPinoy.Models;

namespace PagkaingPinoy.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        //READ CONTOLLER | DISPLAY MENU
        public async Task<IActionResult> Index()
        {
            IEnumerable<Menu> menu = await _menuRepository.GetAll();
            return View(menu);
        }


    }
}
