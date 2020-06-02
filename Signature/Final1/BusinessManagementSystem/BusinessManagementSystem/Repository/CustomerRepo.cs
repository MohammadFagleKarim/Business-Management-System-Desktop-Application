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
    class CustomerRepo
    {
        string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";

        public bool Add(Customer customer)
        {
            bool isAdded = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Category (Code, Name,Address,Email,Contact,LoyalityPoint) Values ('1234', 'arafat','Mirpur-13', 'arafat.reza1997@gmail.com','01625420852', 0)
            string commandString = @"INSERT INTO Customer (Code, Name,Address,Email,Contact,LoyalityPoint) Values ('" + customer.Code + "','" + customer.Name + "','" + customer.Address + "','" + customer.Email + "','" + customer.Contact + "'," + customer.LoyalityPoint + ")";
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

        public bool IsNameExists(Customer customer)
        {
            bool exists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT* FROM Category WHERE Name = 'Mobile'
            string commandString = @"SELECT * FROM Customer WHERE Name ='" + customer.Name + "'";
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

        public bool IsCodeExists(Customer customer)
        {
            bool exists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT* FROM Category WHERE Code = '0001'
            string commandString = @"SELECT * FROM Customer WHERE Code='" + customer.Code + "'";
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

        public bool IsContactExists(Customer customer)
        {
            bool exists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM Customer WHERE Contact ='" + customer.Contact + "'";
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

        public bool IsEmailExists(Customer customer)
        {
            bool exists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM Customer WHERE Email ='" + customer.Email + "'";
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

        public bool Edit(Customer customer)
        {
            bool isupdate = false;
            
            //Connection

            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS;Database=BusinessManagementSystem;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            string commandString = @"UPDATE Customer SET Code = '" + customer.Code + "', Name = '" + customer.Name + "',Address = '" + customer.Address + "', Email = '" + customer.Email + "',Contact = '" + customer.Contact + "' WHERE ID = " + customer.Id + " ";
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

        public List<Customer> Display()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT * FROM Customer
            string commandString = @"SELECT * FROM Customer";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Customer> customers = new List<Customer>();

            while (sqlDataReader.Read())
            {
                Customer customer = new Customer();
                customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                customer.Code = sqlDataReader["Code"].ToString();
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                customer.Email = sqlDataReader["Email"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
                customer.LoyalityPoint = Convert.ToInt32(sqlDataReader["LoyalityPoint"]);

                customers.Add(customer);
            }
            
            //Close
            sqlConnection.Close();

            return customers;
        }

        public List<Customer> SearchByChar(string search)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT * FROM Customer WHERE Code like '" + search + "%' OR Name like '" + search + "%' OR Contact like '" + search + "%' OR Email like '" + search + "%'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            
            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Customer> customers = new List<Customer>();

            while (sqlDataReader.Read())
            {
                Customer customer = new Customer();
                customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                customer.Code = sqlDataReader["Code"].ToString();
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                customer.Email = sqlDataReader["Email"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
                customer.LoyalityPoint = Convert.ToInt32(sqlDataReader["LoyalityPoint"]);

                customers.Add(customer);
            }
            
            //Close
            sqlConnection.Close();

            return customers;
        }

        public List<Customer> Search(string search)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM Customer WHERE Code ='" + search + "' OR Name = '" + search + "'OR Contact = '" + search + "'OR Email = '" + search + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();
            
            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Customer> customers = new List<Customer>();

            while (sqlDataReader.Read())
            {
                Customer customer = new Customer();
                customer.Id = Convert.ToInt32(sqlDataReader["Id"]);
                customer.Code = sqlDataReader["Code"].ToString();
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                customer.Email = sqlDataReader["Email"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
                customer.LoyalityPoint = Convert.ToInt32(sqlDataReader["LoyalityPoint"]);

                customers.Add(customer);
            }
            
            //Close
            sqlConnection.Close();

            return customers;
        }
    }
}
