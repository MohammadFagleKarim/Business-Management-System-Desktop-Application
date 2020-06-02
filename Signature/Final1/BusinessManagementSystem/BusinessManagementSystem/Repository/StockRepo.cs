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
    class StockRepo
    {
        string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";

        public List<Stocks> Display()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT Code,Name,Category,ReorderLevel,ExpireDate,Opening_Balance,newinn,newout,Closing_Balance FROM Stock,InOut
            string commandString = @"SELECT Code,Name,Category,ReorderLevel,ExpireDate,Opening_Balance,newinn,newout,Closing_Balance FROM Stock,InOut";
            //string commandStrings = @"SELECT SUM(inn) as inn,SUM(Out) as out FROM Stock";

            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //SqlCommand sqlCommands = new SqlCommand(commandStrings, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //SqlDataReader sqlDataReaders = sqlCommands.ExecuteReader();

            List<Stocks> Stocks = new List<Stocks>();
            Stocks Stock = new Stocks();

            while (sqlDataReader.Read())
            {
                //while (sqlDataReaders.Read())
                //{

                //    Stock.inn = Convert.ToInt32(sqlDataReader["inn"]);
                //    Stock.Out = Convert.ToInt32(sqlDataReader["out"]);
                //}


                //Stocks Stock = new Stocks();
                Stock.Code = sqlDataReader["Code"].ToString();
                Stock.Name = sqlDataReader["Name"].ToString();
                Stock.Category = sqlDataReader["Category"].ToString();
                Stock.ReorderLevel = Convert.ToInt32(sqlDataReader["ReorderLevel"].ToString());
                Stock.ExpireDate = Convert.ToDateTime(sqlDataReader["ExpireDate"].ToString());
                Stock.Opening_Balance = Convert.ToInt32(sqlDataReader["Opening_Balance"]);
                 Stock.inn = Convert.ToInt32(sqlDataReader["newinn"]);
                 Stock.Out = Convert.ToInt32(sqlDataReader["newout"]);
                Stock.Closing_Balance = Convert.ToInt32(sqlDataReader["Closing_Balance"]);


                Stocks.Add(Stock);
            }

            //Close
            sqlConnection.Close();

            return Stocks;
        }

        public List<Stocks> SearchByChar(Stocks Stock)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT s.Code,s.Name,s.Category,s.ReorderLevel,s.ExpireDate,s.Opening_Balance,i.newinn,i.newout,s.Closing_Balance FROM Stock as s,InOut as i,Purchase as pu WHERE pu.Date BETWEEN '2017-06-22' AND '2019-06-22' or Name = 'RM 2' or Category = 'Mobile' 
            string commandString = @"SELECT s.Code,s.Name,s.Category,s.ReorderLevel,s.ExpireDate,s.Opening_Balance,i.newinn,i.newout,s.Closing_Balance FROM Stock as s,InOut as i,Purchase as pu WHERE pu.Date BETWEEN '" + Stock .StartDate + "' AND '" + Stock.EndDate + "' or Name like '" + Stock.ProductName + "%' or Category like '" + Stock.Category + "%' ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Stocks>  Stocks = new List<Stocks>();

            while (sqlDataReader.Read())
            {
                
                Stock.Code = sqlDataReader["Code"].ToString();
                Stock.Name = sqlDataReader["Name"].ToString();
                Stock.Category = sqlDataReader["Category"].ToString();
                Stock.ReorderLevel = Convert.ToInt32(sqlDataReader["ReorderLevel"].ToString());
                Stock.ExpireDate = Convert.ToDateTime(sqlDataReader["ExpireDate"].ToString());
                Stock.Opening_Balance = Convert.ToInt32(sqlDataReader["Opening_Balance"]);
                Stock.inn = Convert.ToInt32(sqlDataReader["newinn"]);
                Stock.Out = Convert.ToInt32(sqlDataReader["newout"]);
                Stock.Closing_Balance = Convert.ToInt32(sqlDataReader["Closing_Balance"]);

                Stocks.Add(Stock);
            }
            
            //Close
            sqlConnection.Close();

            return Stocks;
        }

        public List<Stocks> Search(Stocks Stock)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT s.Code,s.Name,s.Category,s.ReorderLevel,s.ExpireDate,s.Opening_Balance,i.newinn,i.newout,s.Closing_Balance FROM Stock as s,InOut as i,Purchase as pu WHERE pu.Date BETWEEN '2017-06-22' AND '2019-06-22' or Name = 'RM 2' or Category = 'Mobile' 
            string commandString = @"SELECT s.Code,s.Name,s.Category,s.ReorderLevel,s.ExpireDate,s.Opening_Balance,i.newinn,i.newout,s.Closing_Balance FROM Stock as s,InOut as i,Purchase as pu WHERE pu.Date BETWEEN '" + Stock.StartDate + "' AND '" + Stock.EndDate + "' or Name = '" + Stock.ProductName + "' or Category = '" + Stock.Category + "' ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Stocks> Stocks = new List<Stocks>();

            while (sqlDataReader.Read())
            {
                
                Stock.Code = sqlDataReader["Code"].ToString();
                Stock.Name = sqlDataReader["Name"].ToString();
                Stock.Category = sqlDataReader["Category"].ToString();
                Stock.ReorderLevel = Convert.ToInt32(sqlDataReader["ReorderLevel"].ToString());
                Stock.ExpireDate = Convert.ToDateTime(sqlDataReader["ExpireDate"].ToString());
                Stock.Opening_Balance = Convert.ToInt32(sqlDataReader["Opening_Balance"]);
                Stock.inn = Convert.ToInt32(sqlDataReader["newinn"]);
                Stock.Out = Convert.ToInt32(sqlDataReader["newout"]);
                Stock.Closing_Balance = Convert.ToInt32(sqlDataReader["Closing_Balance"]);

                Stocks.Add(Stock);
            }

            //Close
            sqlConnection.Close();

            return Stocks;
        }

        public List<Stocks> SaleDisplay()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT sa.Code ,sa.Name,sa.Category,SQ.SoldQty,sa.CP, sa.Sales_Price, sa.Profit FROM Sale as sa,SoldQty as SQ
            string commandString = @"SELECT sa.Code ,sa.Name,sa.Category,SQ.SoldQty,sa.CP, sa.Sales_Price, sa.Profit FROM Sale as sa,SoldQty as SQ";
            //string commandStrings = @"SELECT SUM(inn) as inn,SUM(Out) as out FROM Stock";

            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //SqlCommand sqlCommands = new SqlCommand(commandStrings, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //SqlDataReader sqlDataReaders = sqlCommands.ExecuteReader();

            List<Stocks> Stocks = new List<Stocks>();
            Stocks Stock = new Stocks();

            while (sqlDataReader.Read())
            {
                //while (sqlDataReaders.Read())
                //{

                //    Stock.inn = Convert.ToInt32(sqlDataReader["inn"]);
                //    Stock.Out = Convert.ToInt32(sqlDataReader["out"]);
                //}


                //Stocks Stock = new Stocks();
                Stock.Code = sqlDataReader["Code"].ToString();
                Stock.Name = sqlDataReader["Name"].ToString();
                Stock.Category = sqlDataReader["Category"].ToString();
                Stock.SoldQuantity = Convert.ToInt32(sqlDataReader["SoldQty"].ToString());
                Stock.CP = Convert.ToDouble(sqlDataReader["CP"]);
                Stock.SalesPrice = Convert.ToDouble(sqlDataReader["Sales_Price"]);
                Stock.Profit = Convert.ToDouble(sqlDataReader["Profit"]);

                Stocks.Add(Stock);
            }
            
            //Close
            sqlConnection.Close();

            return Stocks;
        }

        public List<Stocks> SaleSearch(Stocks Stock)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT sa.Code ,sa.Name,sa.Category,SQ.SoldQty,sa.CP, sa.Sales_Price, sa.Profit FROM Sale as sa,SoldQty as SQ,Sales as s WHERE s.Date BETWEEN '2017-06-22' AND '2019-06-22'
            string commandString = @"SELECT sa.Code ,sa.Name,sa.Category,SQ.SoldQty,sa.CP, sa.Sales_Price, sa.Profit FROM Sale as sa,SoldQty as SQ,Sales as s WHERE s.Date BETWEEN '" + Stock.StartDate + "' AND '" + Stock.EndDate + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Stocks> Stocks = new List<Stocks>();

            while (sqlDataReader.Read())
            {

                //Stocks Stock = new Stocks();
                Stock.Code = sqlDataReader["Code"].ToString();
                Stock.Name = sqlDataReader["Name"].ToString();
                Stock.Category = sqlDataReader["Category"].ToString();
                Stock.SoldQuantity = Convert.ToInt32(sqlDataReader["SoldQty"].ToString());
                Stock.CP = Convert.ToDouble(sqlDataReader["CP"]);
                Stock.SalesPrice = Convert.ToDouble(sqlDataReader["Sales_Price"]);
                Stock.Profit = Convert.ToDouble(sqlDataReader["Profit"]);


                Stocks.Add(Stock);
            }

            //Close
            sqlConnection.Close();

            return Stocks;
        }

        public List<Stocks> PurchaseDisplay()
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT * FROM Purchases
            string commandString = @"SELECT * FROM Purchases";
            //string commandStrings = @"SELECT SUM(inn) as inn,SUM(Out) as out FROM Stock";

            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            //SqlCommand sqlCommands = new SqlCommand(commandStrings, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //SqlDataReader sqlDataReaders = sqlCommands.ExecuteReader();

            List<Stocks> Stocks = new List<Stocks>();
            Stocks Stock = new Stocks();

            while (sqlDataReader.Read())
            {
                //while (sqlDataReaders.Read())
                //{

                //    Stock.inn = Convert.ToInt32(sqlDataReader["inn"]);
                //    Stock.Out = Convert.ToInt32(sqlDataReader["out"]);
                //}


                //Stocks Stock = new Stocks();
                Stock.Code = sqlDataReader["Code"].ToString();
                Stock.Name = sqlDataReader["Name"].ToString();
                Stock.Category = sqlDataReader["Category"].ToString();
                Stock.AvailableQuantity = Convert.ToInt32(sqlDataReader["AvailableQuantity"].ToString());
                Stock.CP = Convert.ToDouble(sqlDataReader["CP"]);
                Stock.MRP = Convert.ToDouble(sqlDataReader["MRP"]);
                Stock.Profit = Convert.ToDouble(sqlDataReader["Profit"]);

                Stocks.Add(Stock);
            }
            
            //Close
            sqlConnection.Close();

            return Stocks;
        }
        
        public List<Stocks> PurchaseSearch(Stocks Stock)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //SELECT * FROM Purchases,Purchase as pu WHERE pu.Date BETWEEN '2017-06-22' AND '2019-06-22'
            string commandString = @"SELECT * FROM Purchases,Purchase as pu WHERE pu.Date BETWEEN '" + Stock.StartDate + "' AND '" + Stock.EndDate + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Stocks> Stocks = new List<Stocks>();

            while (sqlDataReader.Read())
            {

                //Stocks Stock = new Stocks();
                Stock.Code = sqlDataReader["Code"].ToString();
                Stock.Name = sqlDataReader["Name"].ToString();
                Stock.Category = sqlDataReader["Category"].ToString();
                Stock.AvailableQuantity = Convert.ToInt32(sqlDataReader["AvailableQuantity"].ToString());
                Stock.CP = Convert.ToDouble(sqlDataReader["CP"]);
                Stock.MRP = Convert.ToDouble(sqlDataReader["MRP"]);
                Stock.Profit = Convert.ToDouble(sqlDataReader["Profit"]);

                Stocks.Add(Stock);
            }

            //Close
            sqlConnection.Close();

            return Stocks;
        }

        public List<Stocks> InOut(Stocks Stock)
        {
            //Connection
            //string connectionString = @"Server=DESKTOP-0LIAG2C\SQLEXPRESS; Database=BusinessManagementSystem; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Command 
            //PurchasSELECT SUM(inn) as inn,SUM(Out) as out FROM Stocke WHERE Date BETWEEN '2017-06-22' AND '2019-06-22' or Name = 'RM 2' or Category = 'Mobile' 
            string commandString = @"SELECT s.Code,s.Name,s.Category,s.ReorderLevel,s.ExpireDate,s.Opening_Balance,s.inn,s.Out,s.Closing_Balance FROM Stock as s,Purchase as pu WHERE pu.Date BETWEEN '" + Stock.StartDate + "' AND '" + Stock.EndDate + "' or Name = '" + Stock.ProductName + "' or Category = '" + Stock.Category + "' ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open
            sqlConnection.Open();

            //With DataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Stocks> Stocks = new List<Stocks>();

            while (sqlDataReader.Read())
            {

                Stock.Code = sqlDataReader["Code"].ToString();
                Stock.Name = sqlDataReader["Name"].ToString();
                Stock.Category = sqlDataReader["Category"].ToString();
                Stock.ReorderLevel = Convert.ToInt32(sqlDataReader["ReorderLevel"].ToString());
                Stock.ExpireDate = Convert.ToDateTime(sqlDataReader["ExpireDate"].ToString());
                Stock.Opening_Balance = Convert.ToInt32(sqlDataReader["Opening_Balance"]);
                Stock.inn = Convert.ToInt32(sqlDataReader["inn"]);
                Stock.Out = Convert.ToInt32(sqlDataReader["Out"]);
                Stock.Closing_Balance = Convert.ToInt32(sqlDataReader["Closing_Balance"]);


                Stocks.Add(Stock);
            }
            
            //Close
            sqlConnection.Close();

            return Stocks;
        }
    }
}
