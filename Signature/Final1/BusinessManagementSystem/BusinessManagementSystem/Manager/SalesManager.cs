using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using BusinessManagementSystem.Model;
using BusinessManagementSystem.Repository;

namespace BusinessManagementSystem.Manager
{
    public class SalesManager
    {
        SalesRepo _salesRepo = new SalesRepo();

        public bool SalesAdd(SalesProduct salesProduct)
        {

            return _salesRepo.SalesAdd(salesProduct);
        }

        public List<SalesProduct> Display()
        {

            return _salesRepo.Display();
        }

        public DataTable CategoryCombo()
        {
            return _salesRepo.CategoryCombo();
        }

        public DataTable ProductCombo()
        {
            return _salesRepo.ProductCombo();
        }

        public DataTable CustomerCombo()
        {
            return _salesRepo.CustomerCombo();
        }
        public double AvailableQuantity(SalesProduct salesProduct)
        {
            return _salesRepo.AvailableQuantity(salesProduct);
        }

        public bool UpdateAvailableQuantitySale(SalesProduct salesProduct)
        {
            return _salesRepo.UpdateAvailableQuantitySale(salesProduct);
        }

        public bool UpdateAvailableQuantityPurchase(SalesProduct salesProduct)
        {
            return _salesRepo.UpdateAvailableQuantityPurchase(salesProduct);
        }

        public bool Submit(Sales sales)
        {
            return _salesRepo.Submit(sales);
        }

    }
}
