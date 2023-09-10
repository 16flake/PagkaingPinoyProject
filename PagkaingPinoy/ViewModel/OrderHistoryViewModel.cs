using PagkaingPinoy.Models;

namespace PagkaingPinoy.ViewModel
{
    public class OrderHistoryViewModel
    {
        public int Id { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public int OrderDetail { get; set; }

        public int Total { get; set; }
    }
}
