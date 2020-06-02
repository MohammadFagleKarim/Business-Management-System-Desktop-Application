using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessManagementSystem.Model;
using BusinessManagementSystem.Repository;

namespace BusinessManagementSystem.Manager
{
    class StockManager
    {
        StockRepo _stockRepo = new StockRepo();

        public List<Stocks> Display()
        {
            return _stockRepo.Display();
        }

        public List<Stocks> SearchByChar(Stocks Stock)
        {
            return _stockRepo.SearchByChar(Stock);
        }
        public List<Stocks> Search(Stocks Stock)
        {
            return _stockRepo.Search(Stock);
        }

        public List<Stocks> SaleDisplay()
        {
            return _stockRepo.SaleDisplay();
        }

        public List<Stocks> SaleSearch(Stocks Stock)
        {
            return _stockRepo.SaleSearch(Stock);
        }

        public List<Stocks> PurchaseDisplay()
        {
            return _stockRepo.PurchaseDisplay();
        }

        public List<Stocks> PurchaseSearch(Stocks Stock)
        {
            return _stockRepo.PurchaseSearch(Stock);
        }
    }
}
