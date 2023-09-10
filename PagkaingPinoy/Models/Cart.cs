using System.ComponentModel.DataAnnotations;

namespace PagkaingPinoy.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public string DishName { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public int Subtotal { get; set; }
    }
}
