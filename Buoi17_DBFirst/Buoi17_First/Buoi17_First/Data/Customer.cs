using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi17_First.Data
{
    [Table("Customer")]
    public class Customer
    {
        public Guid CustomerId { get; set; }

        [MaxLength(150)]
        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(30)]
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? RandomKey { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
            // Orders = new HashSet<Order>();
        }
    }
}
