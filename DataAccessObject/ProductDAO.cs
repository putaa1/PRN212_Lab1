using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class ProductDAO : BaseDAL
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock(instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        //--------------------------------
        public IEnumerable<Product> GetProducts()
        {
            SqlDataReader dataReader = null;
            string SQL = "Select * from Products";
            var products = new List<Product>();
            try
            {
                dataReader = StockDataProvider.GetDataReader(SQL, CommandType.Text);
                while (dataReader.Read())
                {
                    products.Add(new Product()
                    {
                        ProductId = dataReader.GetInt32("ProductID"),
                        ProductName = dataReader.GetString("ProductName"),
                        CategoryID = dataReader.GetInt32("CategoryID"),
                        UnitPrice = dataReader.GetDecimal("UnitPrice"),
                        UnitsInStock = dataReader.GetInt16("UnitsInStock")
                    });
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return products;
        }
        //--------------------------------
        public void SaveProduct(Product p)
        {
            try
            {
                string SQL = "Insert Products values(@ProductName, @CategoryID, @UnitPrice, @UnitsInStock)";
                var parameters = new List<SqlParameter>()
                {
                    StockDataProvider.CreateParameter("@ProductName", 40, p.ProductName, DbType.String),
                    StockDataProvider.CreateParameter("@CategoryID", 4, p.CategoryID, DbType.Int32),
                    StockDataProvider.CreateParameter("@UnitPrice", 4, p.UnitPrice, DbType.Decimal),
                    StockDataProvider.CreateParameter("@UnitsInStock", 4, p.UnitsInStock, DbType.Int16)
                };
                StockDataProvider.Insert(SQL, CommandType.Text, parameters.ToArray());
            }
            catch(Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
            finally
            {
                CloseConnection();
            }
        }
        //--------------------------------
        public void UpdateProduct(Product product)
        {
            try
            {
                string SQL = "Update Products set ProductName = @ProductName, CategoryID = @CategoryID, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock where ProductID = @ProductID";
                var parameters = new List<SqlParameter>()
                {
                    StockDataProvider.CreateParameter("@ProductName", 40, product.ProductName, DbType.String),
                    StockDataProvider.CreateParameter("@CategoryID", 4, product.CategoryID, DbType.Int32),
                    StockDataProvider.CreateParameter("@UnitPrice", 4, product.UnitPrice, DbType.Decimal),
                    StockDataProvider.CreateParameter("@UnitsInStock", 4, product.UnitsInStock, DbType.Int16),
                    StockDataProvider.CreateParameter("@ProductID", 4, product.ProductId, DbType.Int32)
                };
                StockDataProvider.Update(SQL, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //--------------------------------
        public void DeleteProduct(Product product)
        {
            try
            {
                string SQL = "Delete Products where ProductID = @ProductID";
                var parameters = new List<SqlParameter>()
                {
                    StockDataProvider.CreateParameter("@ProductID", 4, product.ProductId, DbType.Int32),
                };
                StockDataProvider.Delete(SQL, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //--------------------------------
        public Product GetProductById(int id)
        {
            SqlDataReader dataReader = null;
            string SQL = "Select * from Products where ProductID = @ProductID";
            Product product = null;
            try
            {
                var param = StockDataProvider.CreateParameter("@ProductID", 4, id, DbType.Int32);
                dataReader = StockDataProvider.GetDataReader(SQL, CommandType.Text, param);
                if (dataReader.Read())
                {
                    product = new Product()
                    {
                        ProductId = dataReader.GetInt32("ProductID"),
                        ProductName = dataReader.GetString("ProductName"),
                        CategoryID = dataReader.GetInt32("CategoryID"),
                        UnitPrice = dataReader.GetDecimal("UnitPrice"),
                        UnitsInStock = dataReader.GetInt16("UnitsInStock")
                    };
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
            return product;
        }


    }
}
