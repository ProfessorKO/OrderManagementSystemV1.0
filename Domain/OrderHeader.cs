using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderHeader
    {
        /// <summary>
        /// OrderHeader Class field of a OrderItem type List
        /// </summary>
        public List<OrderItem> _orderItems = new List<OrderItem>();

        /// <summary>
        /// OrderHeader Class property of count of the OrderItem type List
        /// </summary>
        public int ItemNumber
        { get { return _orderItems.Count; }
        }

        /// <summary>
        /// OrderHeader Class property of record date and time of creation
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// OrderHeader Class property of order header Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// OrderHeader Class property of order header state (1,2,3,and 4)
        /// </summary>
        public int _orderState;

        /// <summary>
        /// OrderHeader Class property of order header state (new, pending, complete, and rejected)
        /// </summary>
        public OrderStates State 
        {
            get { return (OrderStates)_orderState; } // OrderStates is enum type (OrderStates)_orderState returns text 
        }

        /// <summary>
        /// OrderHeader Class property of total dollar value of the orde header
        /// </summary>
        public decimal Total 
        { get
            {
                decimal total = 0;
                for (int i = 0; i<_orderItems.Count;i++)
                {
                    total += _orderItems[i].Total;
                }
                return total; // return _orderItems.Count;
            }
        }

        /// <summary>
        /// OrderHeader Class Constructor with 3 parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stateId"></param>
        /// <param name="dataTime"></param>
        public OrderHeader(int id, int stateId, DateTime dataTime)
        {
            Id = id;
            _orderState = stateId;
            DateTime = dataTime;
        }

        /// <summary>
        /// OrderHeader Class method for updating or adding new order itme to the List. If there is alreay an order item of the same
        /// stock item, the order quantity will get added on by the new orde item quantity and no new orde item will be generated.
        /// </summary>
        /// <param name="orderHeaderId"></param>
        /// <param name="stockId"></param>
        /// <param name="desc"></param>
        /// <param name="price"></param>
        /// <param name="qty"></param>
        /// <returns></returns>
        public OrderItem UpdateOrderItem(int orderHeaderId, int stockId, string desc, decimal price, int qty)
        {
            // check if there is order item in the current order header or not
            OrderItem orderItem = null;
            foreach (OrderItem item in _orderItems)
            {
                if (item.StockItemId == stockId) 
                {
                    orderItem = item; // two becomes one, sort of overwriting they have the same properties anyway except for qty so only needs to update qty
                }
            }
            // create a new item
            if (orderItem != null) // there is existing order item in the system
            {
                orderItem.Quantity += qty;
            }
            else
            {
                orderItem = new OrderItem(this, orderHeaderId, stockId, desc, price, qty);
                _orderItems.Add(orderItem);
            }

            return orderItem;
        }

        public void Complete()
        {

        }

        public void Reject()
        {

        }

        public void SetState()
        {

        }

        public void Submit()
        {

        }

    }
}
