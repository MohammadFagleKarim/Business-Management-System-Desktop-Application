using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Model
{
    public class Purchase
    {
        public int Id { set; get; }

        public string Code { set; get; }

        public string Date { set; get; }

        public string Bill { set; get; }

        public int SupplierId { set; get; }
    }
}
