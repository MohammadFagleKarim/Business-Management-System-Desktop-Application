using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BusinessManagementSystem.Model;
using BusinessManagementSystem.Repository;

namespace BusinessManagementSystem.Manager
{
    public class PurchaseManager
    {
        PurchaseRepo _PurchaseRepo = new PurchaseRepo();

        public DataTable SupplierComboLoad()
        {
            return _PurchaseRepo.SupplierComboLoad();
        }

        public DataTable CategoryComboLoad()
        {
            return _PurchaseRepo.CategoryComboLoad();
        }

        public DataTable ProductComboLoad(int categoryId)
        {
            return _PurchaseRepo.ProductComboLoad(categoryId);
        }

        public bool IsInvoiceNoExists(Purchase purchase)
        {
            return _PurchaseRepo.IsInvoiceNoExists(purchase);
        }

        public bool IsCodeExists(Purchase purchase)
        {
            return _PurchaseRepo.IsCodeExists(purchase);
        }

        public string LoadProductCode(Product product)
        {
            return _PurchaseRepo.LoadProductCode(product);
        }

        public int LoadPurchaseQuantity(PurchaseItems purchaseItems)
        {
            return _PurchaseRepo.LoadPurchaseQuantity(purchaseItems);
        }

        //public DataTable LoadSalesQuantity(PurchaseItems purchaseItems)
        //{
        //    return _PurchaseRepo.LoadSalesQuantity(purchaseItems);
        //}

        public int AvailableQuantity(PurchaseItems purchaseItems)
        {
            return _PurchaseRepo.AvailableQuantity(purchaseItems);
        }

        public double LoadPreviousUnitPrice(PurchaseItems purchaseItems)
        {
            return _PurchaseRepo.LoadPreviousUnitPrice(purchaseItems);
        }

        public double LoadPreviousMrp(PurchaseItems purchaseItems)
        {
            return _PurchaseRepo.LoadPreviousMrp(purchaseItems);
        }

        public DataTable Display()
        {
            return _PurchaseRepo.Display();
        }

        public bool SubmitSupplierInfo(Purchase purchase)
        {
            return _PurchaseRepo.SubmitSupplierInfo(purchase);
        }

        public int SearchPurchaseId(Purchase purchase)
        {
            return _PurchaseRepo.SearchPurchaseId(purchase);
        }

        public bool SubmitPurchaseItemsInfo(PurchaseItems purchaseItem)
        {
            return _PurchaseRepo.SubmitPurchaseItemsInfo(purchaseItem);
        }
    }
}
