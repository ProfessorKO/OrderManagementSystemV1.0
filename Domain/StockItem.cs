using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StockItem
    {
        /// <summary>
        /// StockItem Class property of stock Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// StockItem Class property of stock quantity
        /// </summary>
        public int InStock { get; set; }

        /// <summary>
        /// StockItem Class property of stock name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// StockItem Class property of stock unit price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// StockItem Class Constructor with 4 parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemName"></param>
        /// <param name="itemPrice"></param>
        /// <param name="itemStock"></param>
        public StockItem(int id, string itemName, decimal itemPrice, int itemStock)
        {
            Id = id;
            Name = itemName;
            Price = itemPrice;
            InStock = itemStock;
        }



    }
}
