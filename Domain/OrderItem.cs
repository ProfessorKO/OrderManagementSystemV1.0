using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderItem
    {
        /// <summary>
        /// OrderItem Class property of item name
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// OrderItem Class property of attached order header in OrderHeader type
        /// </summary>
        public OrderHeader OrderHeader { get; set; }

        /// <summary>
        /// OrderItem Class property of attached order heade Id
        /// </summary>
        public int OrderHeaderId { get; set; }

        /// <summary>
        /// OrderItem Class property of order item's unit price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// OrderItem Class property of order item's quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// OrderItem Class property of order item's stock Id
        /// </summary>
        public int StockItemId { get; set; }

        /// <summary>
        /// OrderItem Class property of order item's total dollar value
        /// </summary>
        public decimal Total
        {
            get { return Price * Quantity; }
            // was set; showing error "must declare a body because it is not marked abstract extern or partial"
        }

        /// <summary>
        /// OrderItem Class Constructor with 6 parameters
        /// </summary>
        /// <param name="orderHeader"></param>
        /// <param name="orderheaderId"></param>
        /// <param name="stockId"></param>
        /// <param name="desc"></param>
        /// <param name="price"></param>
        /// <param name="qty"></param>
        public OrderItem (OrderHeader orderHeader, int orderheaderId, int stockId, string desc, decimal price, int qty)
        {
            OrderHeader = orderHeader;
            OrderHeaderId = orderheaderId;
            StockItemId = stockId;
            Description = desc;
            Price = price;
            Quantity = qty;
        }

    }




}

