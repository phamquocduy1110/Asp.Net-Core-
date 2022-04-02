using Microsoft.AspNetCore.Mvc;

namespace NhatNgheDay01Demo.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        /*public double Total
        {
            get { return Price * Quantity; }
        }*/

        public double Total => Quantity * Price;
        public int Count = 0;

    }
}
