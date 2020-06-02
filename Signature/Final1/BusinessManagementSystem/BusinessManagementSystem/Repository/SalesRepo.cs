using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using BusinessManagementSystem.Model;

namespace BusinessManagementSystem.Repository
{
    public class SalesRepo
    {
        string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";

        public bool SalesAdd(SalesProduct salesProduct)
        {
            bool isAdded = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Category (Code, Name) Values ('1234', 'arafat')
            string commandString = @"INSERT INTO SalesProduct (CategoryId, ProductId,AvailableQuantity,Quantity,MRP,TotalMRP) Values (" + salesProduct.CategoryId + "," + salesProduct.ProductId + ",'" + salesProduct.AvailableQuantity + "','" + salesProduct.Quantity + "','" + salesProduct.MRP + "','" + salesProduct.TotalMRP + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Insert

            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                isAdded = true;
            }
            
            //Close
            sqlConnection.Close();
            
            return isAdded;
        }
        
        public bool Submit(Sales sales)
        {
            bool isSubmit = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Category (Code, Name) Values ('1234', 'arafat')
            string commandString = @"INSERT INTO Sales (CustomerId,Date,LoyalityPoint,GrandTotal,Discount,DiscountAmount,PayableAmount) Values (" + sales.CustomerId + "," + sales.Date + ",'" + sales.LoyalityPoint + "','" + sales.GrandTotal + "','" + sales.Discount + "','" + sales.DiscountAmount + "','" + sales.PayableAmount + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Insert

            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                isSubmit = true;
            }
            
            //Close
            sqlConnection.Close();
            
            return isSubmit;
        }

        public DataTable CategoryCombo()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT Name, Id FROM Category";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public DataTable ProductCombo()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT Name, Id FROM Product";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }
        
        public DataTable CustomerCombo()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT Name, Id FROM Customer";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();

            return dataTable;
        }

        public List<SalesProduct> Display()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM SalesProduct";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<SalesProduct> salesProduct = new List<SalesProduct>();

            while (sqlDataReader.Read())
            {
                SalesProduct salesProducts = new SalesProduct();
                salesProducts.Id = Convert.ToInt32(sqlDataReader["Id"]);
                salesProducts.CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]);
                salesProducts.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);
                salesProducts.AvailableQuantity = Convert.ToInt32(sqlDataReader["AvailableQuantity"]);
                salesProducts.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                salesProducts.MRP = Convert.ToInt32(sqlDataReader["MRP"]);
                salesProducts.TotalMRP = Convert.ToInt32(sqlDataReader["TotalMRP"]);

                salesProduct.Add(salesProducts);
            }
            
            //Close
            sqlConnection.Close();

            return salesProduct;
        }

        public double AvailableQuantity(SalesProduct salesProduct)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"Select AvailableQuantity From Purchase WHERE CategoryId ='" + salesProduct.CategoryId + "' And ProductId = '" + salesProduct.ProductId + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            
            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                salesProduct.AvailableQuantity = Convert.ToInt32(sqlDataReader["AvailableQuantity"]);
            }

            double avail = salesProduct.AvailableQuantity;
            //Close
            sqlConnection.Close();

            return avail;
        }

        public bool UpdateAvailableQuantitySale(SalesProduct salesProduct)
        {
            bool isUpdate = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //UPDATE SalesProduct SET AvailableQuantity = 10 WHERE CategoryId = 1 and ProductId = 2;
            string commandString = @"UPDATE SalesProduct SET AvailableQuantity = " + salesProduct.AvailableQuantity + " WHERE CategoryId = " + salesProduct.CategoryId + " and ProductId = " + salesProduct.ProductId + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Insert

            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                isUpdate = true;
            }
            
            //Close
            sqlConnection.Close();
            
            return isUpdate;
        }

        public bool UpdateAvailableQuantityPurchase(SalesProduct salesProduct)
        {
            bool isUpdate = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //UPDATE Purchase SET AvailableQuantity = 10 WHERE CategoryId = 1 and ProductId = 2;
            string commandString = @"UPDATE Purchase SET AvailableQuantity = " + salesProduct.AvailableQuantity + " WHERE CategoryId = " + salesProduct.CategoryId + " and ProductId = " + salesProduct.ProductId + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Insert

            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                isUpdate = true;
            }
            
            //Close
            sqlConnection.Close();
            
            return isUpdate;
        }
    }
}
