using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public partial class Product
    {
        public Product()
        {
        }

        public Product(int id, string name, int catId, short unitInStock, decimal price)
        {
            this.ProductId = id;
            this.ProductName = name;
            this.CategoryID = catId;
            this.UnitsInStock = unitInStock;
            this.UnitPrice = price;
        }

        public int ProductId {  get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public short? UnitsInStock { get; set; }
        public decimal? UnitPrice { get; set;}
        public virtual Category Category { get; set; }
    }
}
