using Microsoft.EntityFrameworkCore;
using PagkaingPinoy.Data;
using PagkaingPinoy.Interface;
using PagkaingPinoy.Models;

namespace PagkaingPinoy.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Menu menu)
        {
            _context.Add(menu);
            return Save();
        }

        public bool Delete(Menu menu)
        {
            _context.Remove(menu);
            return Save();
        }

        public async Task<IEnumerable<Menu>> GetAll()
        {
            return await _context.Menus.ToListAsync();
        }

        public async Task<Menu> GetByIdAsync(int id)
        {
            return await _context.Menus.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Menu menu)
        {
            _context.Update(menu);
            return Save();
        }
    }
}
