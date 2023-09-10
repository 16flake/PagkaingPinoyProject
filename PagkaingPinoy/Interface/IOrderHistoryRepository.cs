using PagkaingPinoy.Models;

namespace PagkaingPinoy.Interface
{
    public interface IOrderHistoryRepository
    {
        Task<IEnumerable<OrderHistory>> GetAll();

        Task<OrderHistory> GetIdByAsync(int id);

        bool Add(OrderHistory orderHistory);

        bool Delete(OrderHistory orderHistory);

        bool Update(OrderHistory orderHistory);

        bool Save();
    }
}
