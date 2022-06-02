using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi17_First.Data
{
    [Table("Order")]
    public class Order
    {
        public Guid OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public Guid CustomerId  { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }


    }
}
