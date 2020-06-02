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
    class SupplierRepo
    {
        string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";

        public bool Add(Supplier supplier)
        {
            bool isAdded = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Category (Code, Name) Values ('1234', 'arafat')
            string commandString = @"INSERT INTO Supplier (Code, Name,Address,Email,Contact,ContactPerson) Values ('" + supplier.Code + "','" + supplier.Name + "','" + supplier.Address + "','" + supplier.Email + "','" + supplier.Contact + "','" + supplier.ContactPerson + "')";
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

        public bool Edit(Supplier supplier)
        {
            bool isupdate = false;
            
            //Connection

            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS;Database=BusinessManagementSystem;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command

            string commandString = @"UPDATE Supplier SET Code = '" + supplier.Code + "', Name = '" + supplier.Name + "',Address = '" + supplier.Address + "', Email = '" + supplier.Email + "',Contact = '" + supplier.Contact + "',ContactPerson = '" + supplier.ContactPerson + "'  WHERE ID = " + supplier.Id + " ";
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

        public bool IsCodeExists(Supplier supplier)
        {
            bool exists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM Supplier WHERE code='" + supplier.Code + "'";
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

        public bool IsContactExists(Supplier supplier)
        {
            bool exists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM Supplier WHERE Contact ='" + supplier.Contact + "'";
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

        public bool IsEmailExists(Supplier supplier)
        {
            bool exists = false;

            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT * FROM Supplier WHERE Email ='" + supplier.Email + "'";
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

        public List<Supplier> Display()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"SELECT * FROM Supplier";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Supplier> supplier = new List<Supplier>();

            while (sqlDataReader.Read())
            {
                Supplier suppliers = new Supplier();
                suppliers.Id = Convert.ToInt32(sqlDataReader["Id"]);
                suppliers.Code = sqlDataReader["Code"].ToString();
                suppliers.Name = sqlDataReader["Name"].ToString();
                suppliers.Address = sqlDataReader["Address"].ToString();
                suppliers.Email = sqlDataReader["Email"].ToString();
                suppliers.Contact = sqlDataReader["Contact"].ToString();
                suppliers.ContactPerson = sqlDataReader["ContactPerson"].ToString();

                supplier.Add(suppliers);
            }
            
            //Close
            sqlConnection.Close();

            return supplier;
        }

        public List<Supplier> Search(string search)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 

            string commandString = @"SELECT*FROM Supplier WHERE Name ='" + search + "' OR Contact = '" + search + "' OR Email = '" + search + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();


            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Supplier> supplier = new List<Supplier>();

            while (sqlDataReader.Read())
            {
                Supplier suppliers = new Supplier();
                suppliers.Id = Convert.ToInt32(sqlDataReader["Id"]);
                suppliers.Code = sqlDataReader["Code"].ToString();
                suppliers.Name = sqlDataReader["Name"].ToString();
                suppliers.Address = sqlDataReader["Address"].ToString();
                suppliers.Email = sqlDataReader["Email"].ToString();
                suppliers.Contact = sqlDataReader["Contact"].ToString();
                suppliers.ContactPerson = sqlDataReader["ContactPerson"].ToString();

                supplier.Add(suppliers);
            }


            //Close
            sqlConnection.Close();

            return supplier;
        }

        public List<Supplier> SearchByChar(string search)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //SELECT * FROM Product WHERE Code like 00% OR Name like t%
            string commandString = @"SELECT * FROM Supplier WHERE Code like '" + search + "%' OR Name like '" + search + "%'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();


            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Supplier> supplier = new List<Supplier>();

            while (sqlDataReader.Read())
            {
                Supplier suppliers = new Supplier();
                suppliers.Id = Convert.ToInt32(sqlDataReader["Id"]);
                suppliers.Code = sqlDataReader["Code"].ToString();
                suppliers.Name = sqlDataReader["Name"].ToString();
                suppliers.Address = sqlDataReader["Address"].ToString();
                suppliers.Email = sqlDataReader["Email"].ToString();
                suppliers.Contact = sqlDataReader["Contact"].ToString();
                suppliers.ContactPerson = sqlDataReader["ContactPerson"].ToString();

                supplier.Add(suppliers);
            }
            
            //Close
            sqlConnection.Close();

            return supplier;
        }
    }
}
