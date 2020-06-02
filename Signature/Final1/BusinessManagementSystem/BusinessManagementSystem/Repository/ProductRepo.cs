using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BusinessManagementSystem.Model;

namespace BusinessManagementSystem.Repository
{
    public class ProductRepo
    {
        string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";

        public bool Add(Product product)
        {
            bool isAdded = false;
            
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"INSERT INTO Product (CategoryId, Code, Name, ReorderLevel, Description) VALUES (" + product.CategoryId + ", '" + product.Code + "', '" + product.Name + "', " + product.ReorderLevel + ", '" + product.Description + "' )";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();

            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted > 0)
            {
                isAdded = true;
            }
            sqlConnection.Close();
            
            return isAdded;
        }

        public bool Edit(Product product)
        {
            bool isupdate = false;
            
            //Connection

            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS;Database=BusinessManagementSystem;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //UPDATE Category SET Code = '0004' , Name = 'fruits' WHERE ID = 4;
            string commandString = @"UPDATE Product SET CategoryId = " + product.CategoryId + ",  Code = '" + product.Code + "', Name = '" + product.Name + "',ReorderLevel ='" + product.ReorderLevel + "', Description = '" + product.Description + "' WHERE Id = " + product.Id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open

            sqlConnection.Open();

            //Execute

            int isexecute = sqlCommand.ExecuteNonQuery();

            if (isexecute > 0)
            {
                isupdate = true;
            }

            //Close

            sqlConnection.Close();

            return isupdate;
        }

        public bool IsCodeExists(Product product)
        {
            bool isExists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT * FROM Product WHERE Code = '" + product.Code + "' ";
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
            sqlConnection.Close();

            return isExists;
        }

        public bool IsNameExists(Product product)
        {
            bool isExists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT * FROM Product WHERE Name = '" + product.Name + "' ";
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
            sqlConnection.Close();
            
            return isExists;
        }

        public List<Product> Display()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            string commandString = @"SELECT * FROM ProductDisplay";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Product> products = new List<Product>();

            while (sqlDataReader.Read())
            {
                Product product = new Product();
                
                product.Code = sqlDataReader["Code"].ToString();
                product.Name = sqlDataReader["Name"].ToString();
                product.Category = sqlDataReader["Category"].ToString();
                product.ReorderLevel = sqlDataReader["ReorderLevel"].ToString();
                product.Description = sqlDataReader["Description"].ToString();

                products.Add(product);
            }

            sqlConnection.Close();

            return products;
        }

        public List<Product> SearchByChar(string search)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //SELECT * FROM ProductDisplay WHERE Code like 00% OR Name like t%
            string commandString = @"SELECT * FROM ProductDisplay WHERE Code like '" + search + "%' OR Name like '" + search + "%'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Product> products = new List<Product>();

            while (sqlDataReader.Read())
            {
                Product product = new Product();


                product.Code = sqlDataReader["Code"].ToString();
                product.Name = sqlDataReader["Name"].ToString();
                product.Category = sqlDataReader["Category"].ToString();
                product.ReorderLevel = sqlDataReader["ReorderLevel"].ToString();
                product.Description = sqlDataReader["Description"].ToString();

                products.Add(product);
            }

            sqlConnection.Close();

            return products;
        }

        public List<Product> Search(string search)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //SELECT * FROM ProductDisplay WHERE Code = '0001' OR Name = 'RM 2'
            string commandString = @"SELECT * FROM ProductDisplay WHERE Name = '" + search + "' OR Code = '" + search + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Execute
            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Product> products = new List<Product>();

            while (sqlDataReader.Read())
            {
                Product product = new Product();


                product.Code = sqlDataReader["Code"].ToString();
                product.Name = sqlDataReader["Name"].ToString();
                product.Category = sqlDataReader["Category"].ToString();
                product.ReorderLevel = sqlDataReader["ReorderLevel"].ToString();
                product.Description = sqlDataReader["Description"].ToString();

                products.Add(product);
            }

            sqlConnection.Close();

            return products;
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
    }
}