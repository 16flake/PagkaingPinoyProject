using PagkaingPinoy.Models;

namespace PagkaingPinoy.Interface
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetAll();
        
        Task<Menu> GetByIdAsync(int id);

        bool Add(Menu menu);

        bool Delete(Menu menu);

        bool Update(Menu menu);

        bool Save();
    }
}
