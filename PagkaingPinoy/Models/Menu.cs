using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace PagkaingPinoy.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        public string Category { get; set; }

        public string DishName { get; set; }

        public string DishAbbreviation { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }
    }
}
