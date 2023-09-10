using PagkaingPinoy.Models;

namespace PagkaingPinoy.Interface
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAll();

        Task<Cart> GetByIdAsync(int id);

        bool Add(Cart cart);

        bool Update(Cart cart);

        bool Delete(Cart cart);

        bool Save();
    }
}
