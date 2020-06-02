using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessManagementSystem.Model
{
   public class Sales
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int CustomerId { get; set; }

        public DateTime Date { get; set; }

        public int LoyalityPoint { get; set; }

        public double GrandTotal { get; set; }

        public double Discount { get; set; }

        public double DiscountAmount { get; set; }

        public double PayableAmount { get; set; }

        private List<SalesProduct> _salesProducts;
    }
}
