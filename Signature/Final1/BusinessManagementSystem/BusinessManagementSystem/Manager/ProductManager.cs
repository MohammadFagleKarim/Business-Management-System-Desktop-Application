﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BusinessManagementSystem.Model;
using BusinessManagementSystem.Repository;

namespace BusinessManagementSystem.Manager
{
    public class ProductManager
    {
        ProductRepo _productRepo = new ProductRepo();

        public bool Add(Product product)
        {
            return _productRepo.Add(product);
        }

        public bool Edit(Product product)
        {
            return _productRepo.Edit(product);
        }

        public bool IsCodeExists(Product product)
        {
            return _productRepo.IsCodeExists(product);
        }

        public bool IsNameExists(Product product)
        {
            return _productRepo.IsNameExists(product);
        }

        public List<Product> Display()
        {
            return _productRepo.Display();
        }

        public List<Product> Search(string search)
        {
            return _productRepo.Search(search);
        }

        public List<Product> SearchByChar(string search)
        {
            return _productRepo.Search(search);
        }

        public DataTable CategoryCombo()
        {
            return _productRepo.CategoryCombo();
        }

    }
}
