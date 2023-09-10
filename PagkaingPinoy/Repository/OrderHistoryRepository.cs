using Microsoft.EntityFrameworkCore;
using PagkaingPinoy.Data;
using PagkaingPinoy.Interface;
using PagkaingPinoy.Models;

namespace PagkaingPinoy.Repository
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(OrderHistory orderHistory)
        {
            _context.Add(orderHistory);
            return Save();
        }

        public bool Delete(OrderHistory orderHistory)
        {
            _context.Remove(orderHistory);
            return Save();
        }

        public async Task<IEnumerable<OrderHistory>> GetAll()
        {
            return await _context.OrderHistories.ToListAsync();
        }

        public async Task<OrderHistory> GetIdByAsync(int id)
        {
            return await _context.OrderHistories.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(OrderHistory orderHistory)
        {
            _context.Update(orderHistory);
            return Save();
        }
    }
}
