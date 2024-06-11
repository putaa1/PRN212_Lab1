using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class BaseDAL
    {
        public StockDataProvider StockDataProvider { get; set; } = null;
        public SqlConnection connection = null;
        public BaseDAL() 
        {
            var connectionString = "Server=(local);uid=sa;pwd=123;database=MyStore;TrustServerCertificate=true";
            StockDataProvider = new StockDataProvider(connectionString);
        }
        //------
        public void CloseConnection() => StockDataProvider.CloseConnection();

    }
}
