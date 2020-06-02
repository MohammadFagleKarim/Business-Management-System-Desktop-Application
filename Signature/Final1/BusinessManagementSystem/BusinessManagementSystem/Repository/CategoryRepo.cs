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
    class CategoryRepo
    {
        string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";

        public bool Add(Category category)
        {
            bool isAdded = false;
            
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Category (Code, Name) Values ('1234', 'arafat')
            string commandString = @"INSERT INTO Category (Code, Name) Values ('" + category.Code + "','" + category.Name + "')";
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

        public bool Edit(Category category)
        {
            bool isupdate = false;
            
            //Connection

            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS;Database=BusinessManagementSystem;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command
            //UPDATE Category SET Code = '0004' , Name = 'fruits' WHERE ID = 4;
            string commandString = @"UPDATE Category SET Code = '" + category.Code + "', Name = '" + category.Name + "' WHERE Id = " + category.Id + " ";
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

        public bool IsNameExists(Category category)
        {
            bool exists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT* FROM Category WHERE Name = 'Mobile'
            string commandString = @"SELECT * FROM Category WHERE Name ='" + category.Name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                exists = true;
            }
            //Close
            sqlConnection.Close();
            
            return exists;
        }

        public bool IsCodeExists(Category category)
        {
            bool exists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT* FROM Category WHERE code = '0003'
            string commandString = @"SELECT * FROM Category WHERE Code='" + category.Code + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            //Show
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                exists = true;
            }
            //Close
            sqlConnection.Close();
            
            return exists;
        }

        public List<Category> Display()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT * FROM Category
            string commandString = @"SELECT * FROM Category";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Category> categories = new List<Category>();

            while (sqlDataReader.Read())
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(sqlDataReader["Id"]);
                category.Code = sqlDataReader["Code"].ToString();
                category.Name = sqlDataReader["Name"].ToString();

                categories.Add(category);
            }

            //Close
            sqlConnection.Close();

            return categories;

        }

        public List<Category> SearchByChar(string search)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //SELECT * FROM Category WHERE Code like 00% OR Name like t%
            string commandString = @"SELECT * FROM Category WHERE Code like '" + search + "%' OR Name like '" + search + "%'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            
            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Category> categories = new List<Category>();

            while (sqlDataReader.Read())
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(sqlDataReader["Id"]);
                category.Code = sqlDataReader["Code"].ToString();
                category.Name = sqlDataReader["Name"].ToString();

                categories.Add(category);
            }
            
            //Close
            sqlConnection.Close();

            return categories;
        }

        public List<Category> Search(string search)
        {

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            ////SELECT * FROM Category WHERE Code = '0001' OR Name = 'Mobile'
            string commandString = @"SELECT*FROM Category WHERE Code ='" + search + "' OR Name = '" + search + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            
            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Category> categories = new List<Category>();

            while (sqlDataReader.Read())
            {
                 Category category = new Category();
                category.Id = Convert.ToInt32(sqlDataReader["Id"]);
                category.Code = sqlDataReader["Code"].ToString();
                category.Name = sqlDataReader["Name"].ToString();

                categories.Add(category);
            }
            
            //Close
            sqlConnection.Close();

            return categories;
        }
    }
}
