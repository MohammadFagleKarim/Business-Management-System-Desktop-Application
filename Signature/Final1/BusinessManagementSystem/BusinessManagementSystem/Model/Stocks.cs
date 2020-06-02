using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Model
{
    public class Stocks
    {
        public string ProductName { set; get; }

        public string CategoryName { set; get; }

        public DateTime StartDate { set; get; }

        public DateTime EndDate { set; get; }

        public string Code { set; get; }

        public string Name { set; get; }

        public string Category { set; get; }

        public int ReorderLevel { set; get; }

        public DateTime ExpireDate { set; get; }

        public int Opening_Balance { set; get; }

        public int inn { set; get; }

        public int Out { set; get; }

        public int Closing_Balance { set; get; }

        public int SoldQuantity { set; get; }

        public double CP { set; get; }

        public double SalesPrice { set; get; }

        public double Profit { set; get; }

        public int AvailableQuantity { set; get; }

        public double MRP { set; get; }








    }
}
