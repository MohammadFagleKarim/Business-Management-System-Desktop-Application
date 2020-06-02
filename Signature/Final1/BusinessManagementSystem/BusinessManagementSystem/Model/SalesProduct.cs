using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Model
{
    public class SalesProduct
    {

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CategoryId { get; set; }

        public int ProductId { get; set; }

        public int SalesId { get; set; }

        public int AvailableQuantity { get; set; }

        public int Quantity { get; set; }

        public double MRP { get; set; }

        public double TotalMRP { get; set; }

        public string ProductName { get; set; }

    }
}
