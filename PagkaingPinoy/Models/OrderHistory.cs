using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace PagkaingPinoy.Models
{
    public class OrderHistory
    {
        [Key]
        public int Id { get; set; }

        public string TransactionDate { get; set; } = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");

        public int NumberOfItems { get; set; }

        public int Total { get; set; }


    }
}
