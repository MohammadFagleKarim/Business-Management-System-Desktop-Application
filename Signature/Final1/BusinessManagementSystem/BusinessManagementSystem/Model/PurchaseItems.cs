using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Model
{
    public class PurchaseItems
    {
        public int Id { set; get; }

        public int CategoryId { set; get; }

        public int ProductId { set; get; }

        public int PurchaseId { set; get; }

        public int AvailableQuantity { set; get; }

        public string ManufacturedDate { set; get; }

        public string ExpireDate { set; get; }

        public int Quantity { set; get; }

        public float UnitPrice { set; get; }

        public float TotalPrice { set; get; }

        public float PreviousUnitPrice { set; get; }

        public float PreviousMRP { set; get; }

        public float MRP { set; get; }

        public string Remarks { set; get; }
    }
}
