using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CategoryDAO : BaseDAL
    {
        private static CategoryDAO instance = null;
        private static readonly object instanceLock = new object();
        private CategoryDAO() { }
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }
        //---------------
        public IEnumerable<Category> GetCategories()
        {
            SqlDataReader dataReader = null;
            string SQL = "Select * from Categories";
            var categories = new List<Category>();
            try
            {
                dataReader = StockDataProvider.GetDataReader(SQL, CommandType.Text);
                while (dataReader.Read())
                {
                    categories.Add(new Category()
                    {
                        CategoryID = dataReader.GetInt32("CategoryID"),
                        CategoryName = dataReader.GetString("CategoryName"),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return categories;
        }

    }
}
