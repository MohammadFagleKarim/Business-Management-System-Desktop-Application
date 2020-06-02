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
    class PurchaseRepo
    {
        string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";

        public DataTable SupplierComboLoad()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT Id, Name FROM Supplier";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //Close
            sqlConnection.Close();

            return dataTable;
        }

        public DataTable CategoryComboLoad()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT Id, Name FROM Category";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //Close
            sqlConnection.Close();

            return dataTable;
        }

        public DataTable ProductComboLoad(int categoryId)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT Id, Name FROM Product WHERE CategoryId = " + categoryId + " ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //Close
            sqlConnection.Close();

            return dataTable;
        }

        public bool IsInvoiceNoExists(Purchase purchases)
        {
            bool isExists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT * FROM Purchase WHERE Bill = '" + purchases.Bill + "' ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                isExists = true;
            }

            //Close
            sqlConnection.Close();

            return isExists;
        }

        public bool IsCodeExists(Purchase purchase)
        {
            bool isExists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT * FROM Purchase WHERE Code = '" + purchase.Code + "' ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                isExists = true;
            }

            //Close
            sqlConnection.Close();

            return isExists;
        }

        private string productCode;
        public string LoadProductCode(Product product)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT Code FROM Product WHERE Name = '" + product.Name + "' ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                productCode = (sqlDataReader["Code"]).ToString();
            }

            //Close
            sqlConnection.Close();

            return productCode;
        }

        public int LoadPurchaseQuantity(PurchaseItems purchaseItems)
        {
            int avail1 = 0;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"Select Quantity From PurchaseItems WHERE CategoryId = " + purchaseItems.CategoryId + " And ProductId = " + purchaseItems.ProductId + " ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                purchaseItems.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
            }

            avail1 = purchaseItems.Quantity;

            //Close
            sqlConnection.Close();

            return avail1;
        }

        public int AvailableQuantity(PurchaseItems purchaseItems)
        {
            int avail = 0;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"Select AvailableQuantity From PurchaseItems WHERE CategoryId = " + purchaseItems.CategoryId + " And ProductId = " + purchaseItems.ProductId + " ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                avail = Convert.ToInt32(sqlDataReader["AvailableQuantity"]);
            }
            
            //Close
            sqlConnection.Close();

            return avail;
        }

        public double LoadPreviousUnitPrice(PurchaseItems purchaseItems)
        {
            double previousUnitPrice = 0;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT PreviousUnitPrice FROM PurchaseItems WHERE CategoryId = " + purchaseItems.CategoryId + " And ProductId = " + purchaseItems.ProductId + " ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                previousUnitPrice = double.Parse((sqlDataReader["PreviousUnitPrice"]).ToString());
            }

            //Close
            sqlConnection.Close();

            return previousUnitPrice;
        }

        public double LoadPreviousMrp(PurchaseItems purchaseItems)
        {
            double previousMrp = 0;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT PreviousMRP FROM PurchaseItems WHERE CategoryId = " + purchaseItems.CategoryId + " And ProductId = " + purchaseItems.ProductId + " ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                previousMrp = double.Parse((sqlDataReader["PreviousMRP"]).ToString());
            }

            //Close
            sqlConnection.Close();

            return previousMrp;
        }

        public DataTable Display()
        {
            //Connection
            string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT * FROM PurchaseDisplay";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //Close
            sqlConnection.Close();

            return dataTable;
        }

        //public List<Purchase> Search(string search)
        //{
        //    //Connection
        //    //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
        //    SqlConnection sqlConnection = new SqlConnection(connectionString);

        //    string commandString = @"SELECT * FROM Purchase WHERE Code like '" + search + " ";
        //    SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

        //    //Open
        //    sqlConnection.Open();

        //    //With DataReader
        //    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        //    List<Purchase> purchases = new List<Purchase>();

        //    while (sqlDataReader.Read())
        //    {
        //        Purchase purchase = new Purchase();
        //        purchase.Id = Convert.ToInt32(sqlDataReader["Id"]);
        //        purchase.Code = sqlDataReader["Code"].ToString();
        //        purchase.Name = sqlDataReader["Name"].ToString();
        //        purchase.Address = sqlDataReader["Address"].ToString();
        //        purchase.Email = sqlDataReader["Email"].ToString();
        //        purchase.Contact = sqlDataReader["Contact"].ToString();
        //        purchase.LoyalityPoint = Convert.ToInt32(sqlDataReader["LoyalityPoint"]);

        //        purchases.Add(purchase);
        //    }

        //    //Close
        //    sqlConnection.Close();

        //    return purchases;
        //}

        public bool SubmitSupplierInfo(Purchase purchase)
        {
            bool isSupplierSubmit = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Category (Code, Name) Values ('1234', 'arafat')
            string commandString = @"INSERT INTO Purchase (Code, Date, Bill, SupplierId) Values ('" + purchase.Code + "', '" + purchase.Date + "', '" + purchase.Bill + "', " + purchase.SupplierId + ")";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Insert

            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted > 0)
            {
                isSupplierSubmit = true;
            }

            //Close
            sqlConnection.Close();

            return isSupplierSubmit;
        }

        public int SearchPurchaseId( Purchase purchase)
        {
            int purchaseId = 0;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT Id FROM Purchase WHERE Code = '" + purchase.Code + "' AND SupplierId = " + purchase.SupplierId + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                purchaseId = Convert.ToInt32(sqlDataReader["Id"]);
            }

            //Close
            sqlConnection.Close();

            return purchaseId;
        }

        public bool SubmitPurchaseItemsInfo(PurchaseItems purchaseItem)
        {
            bool isSupplierSubmit = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Category (Code, Name) Values ('1234', 'arafat')
            string commandString = @"INSERT INTO PurchaseItems (CategoryId, ProductId, PurchaseId, AvailableQuantity, ManufacturedDate, ExpireDate, Quantity, UnitPrice, TotalPrice, PreviousUnitPrice, PreviousMRP, MRP, Remarks) Values (" + purchaseItem.CategoryId + ", " + purchaseItem.ProductId + ", " + purchaseItem.PurchaseId + ", " + purchaseItem.AvailableQuantity + ", '" + purchaseItem.ManufacturedDate + "', '" + purchaseItem.ExpireDate + "', " + purchaseItem.Quantity + ", " + purchaseItem.UnitPrice + ", " + purchaseItem.TotalPrice + ", " + purchaseItem.PreviousUnitPrice + ", " + purchaseItem.PreviousMRP + ", " + purchaseItem.MRP + ", '" + purchaseItem.Remarks + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Insert

            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                isSupplierSubmit = true;
            }

            //Close
            sqlConnection.Close();

            return isSupplierSubmit;
        }
    }
}