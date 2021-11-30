using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.SqlClient;
using System.Configuration;


namespace DataAccess
{
    public class Repository
    {
        private string _connectionString;
        private SqlConnection sqlConn;
        private SqlCommand cmd;

        /// <summary>
        /// Constructor of Repository class
        /// </summary>
        public Repository()
        {
            //TODO: (Task 1) 
            //initialise and assign the correct value for the _connectionString field here using ConfigurationManager. 
            _connectionString = ConfigurationManager.ConnectionStrings["OrderManagementDb"].ConnectionString;
            sqlConn = new SqlConnection(_connectionString);
        }

       /// <summary>
       /// Method for inserting a new order header in Sql and return a OrderHeader type variable with order header Id, state and date/time
       /// </summary>
       /// <returns></returns>
        public OrderHeader InsertOrderHearder()
        {
            OrderHeader orderHeader = null;
            cmd = new SqlCommand("sp_InsertOrderHeader", sqlConn);
            sqlConn.Open();
            int orderHeaderId = Convert.ToInt32(cmd.ExecuteScalar());

            cmd = new SqlCommand("select * from OrderHeaders where Id=" + orderHeaderId,
                sqlConn);
            SqlDataReader dataReader = cmd.ExecuteReader();
            //get the last order header
            if (dataReader.HasRows)
            { while (dataReader.Read())
                {
                    orderHeader = new OrderHeader(orderHeaderId, dataReader.GetInt32(1), dataReader.GetDateTime(2));
                    //orderHeader.Id = dataReader.GetInt32(0);
                    //orderHeader._orderState = dataReader.GetInt32(1);
                    //orderHeader.DateTime = dataReader.GetDateTime(2);
                }
            }

            sqlConn.Close();
            return orderHeader;
        }

        //created outside assessment brief instruction. end up with no use. use datacontext to achive the same purpose
        public OrderHeader GetLastOrderHeader()
        {
            Repository _repo = new Repository();
            OrderHeader orderHeader = null;
            cmd = new SqlCommand("select * from OrderHeaders", sqlConn);
            sqlConn.Open();
            SqlDataReader datareader = cmd.ExecuteReader();
            if (datareader.HasRows)
            {
                while (datareader.Read())
                {
                    if (datareader.GetInt32(1) == 1)
                    {
                        orderHeader = new OrderHeader(datareader.GetInt32(0),
                            datareader.GetInt32(1), datareader.GetDateTime(2));
                    }
                    //else if (datareader.GetInt32(1) != 1)
                    //{
                    //    orderHeader = _repo.InsertOrderHearder();
                    //}
                }

            }

            sqlConn.Close();
            return orderHeader;
        }

        /// <summary>
        /// Method for selecting an order header by its Id and return a OrderHeader type variable and update/add to its OrderItem type List within 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderHeader GetOrderHeader(int id)
        {
            OrderHeader orderHeader = null;
            cmd = new SqlCommand("sp_SelectOrderHeaderById @id=" + id, sqlConn);
            sqlConn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    orderHeader = new OrderHeader(dataReader.GetInt32(0), dataReader.GetInt32(1),
                        dataReader.GetDateTime(2));
                    //orderHeader.Id = dataReader.GetInt32(0);
                    //orderHeader._orderState = dataReader.GetInt32(1);
                    //orderHeader.DateTime = dataReader.GetDateTime(2);

                    // look for OrderItem
                    int stockId = dataReader.GetInt32(3);
                    string desc = dataReader.GetString(4);
                    decimal price = (decimal)dataReader.GetDecimal(5);
                    int qty = dataReader.GetInt32(6);

                    orderHeader.UpdateOrderItem(orderHeader.Id, stockId, desc, price, qty);
                }
            }
            //cmd.ExecuteNonQuery();  //one commmand has one cmd.exucute.. cmd.executenonquery and cmd.executereader conflict
            sqlConn.Close();
            return orderHeader;

        }

        /// <summary>
        /// Methods for selecting all existing order headers and attached order items and return an OrderHeader type List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderHeader> GetOrderHeaders()
        // REASON USING UPDATEORDERITEM METHOD
        // see SQL sp_SelectOrderHeaders is inner joining
        //orderheaders and orderitmes table which is not combining ordered items
        //with the same orderheader ID. but the home interface page shows the
        //number of items rather quantity need updateorderitem method to 
        //combine before hook up with interface
        {
            List<OrderHeader> orderHeaders = new List<OrderHeader>();
            OrderHeader orderHeader = null;
            cmd = new SqlCommand("sp_SelectOrderHeaders", sqlConn);
            sqlConn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();

            if(dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    int orderHeaderId = dataReader.GetInt32(0);
                    if (orderHeader == null || orderHeader.Id != orderHeaderId)
                    {
                        int stateId = dataReader.GetInt32(1);
                        DateTime dateTime = dataReader.GetDateTime(2);

                        orderHeader = new OrderHeader(orderHeaderId, stateId, dateTime);
                        orderHeaders.Add(orderHeader);
                    }

                    // look for OrderItem
                    int stockId = dataReader.GetInt32(3);
                    string desc = dataReader.GetString(4);
                    decimal price = (decimal)dataReader.GetDecimal(5);
                    int qty = dataReader.GetInt32(6);

                    orderHeader.UpdateOrderItem(orderHeaderId, stockId, desc, price, qty);
                }
            }
            //cmd.ExecuteNonQuery();

            sqlConn.Close();
            return orderHeaders;
        }

        /// <summary>
        /// Method for updating/inserting a new order item under a selected order header. If there is alreay an order item of the same
        /// stock item within the selected order header, the quantity will get added on by the new order item quantiy and no new order 
        /// item will be generarted
        /// </summary>
        /// <param name="orderItem"></param>
        public void UpsertOrderItem(OrderItem orderItem)
        {
            cmd = new SqlCommand("sp_UpsertOrderItem1 @orderHeaderId=" + orderItem.OrderHeaderId +
                ",@stockItemId=" + orderItem.StockItemId + ",@description='" + orderItem.Description +"'"
                + ",@price=" + orderItem.Price + ",@quantity=" + orderItem.Quantity,
                sqlConn);
            //cmd.Parameters.AddWithValue("@orderHeaderId", orderItem.OrderHeaderId);
            //cmd.Parameters.AddWithValue("@stockItemId", orderItem.StockItemId);
            //cmd.Parameters.AddWithValue("@description", orderItem.Description);
            //cmd.Parameters.AddWithValue("@price", orderItem.Price);
            //cmd.Parameters.AddWithValue("@quantity", orderItem.Quantity);
            sqlConn.Open();
            
            cmd.ExecuteNonQuery();
            sqlConn.Close();
        }

        /// <summary>
        /// Method for changing order state
        /// </summary>
        /// <param name="orderHeader"></param>
        public void UpdateOrderState(OrderHeader orderHeader)
        {
            cmd = new SqlCommand("sp_UpdateOrderState @orderHeaderId " +
                "@stateId", sqlConn);
            cmd.Parameters.AddWithValue("@orderHeaderId", orderHeader.Id);
            cmd.Parameters.AddWithValue("@stateId", orderHeader._orderState);
            sqlConn.Open();
            cmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        /// <summary>
        /// Method for changing order state from new to pending
        /// </summary>
        /// <param name="orderHeader"></param>
        public void UpdateOrderStateNewToPending(OrderHeader orderHeader)
        {
            cmd = new SqlCommand("sp_UpdateOrderState @orderHeaderId " +
                ",@stateId=2", sqlConn);
            cmd.Parameters.AddWithValue("@orderHeaderId", orderHeader.Id);
            //cmd.Parameters.AddWithValue("@stateId", orderHeader._orderState);
            sqlConn.Open();
            cmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        /// <summary>
        /// Method for chaning order state from pending to complete
        /// </summary>
        /// <param name="orderHeader"></param>
        public void UpdateOrderStatePendingToCompleted(OrderHeader orderHeader)
        {
            cmd = new SqlCommand("sp_UpdateOrderState @orderHeaderId " +
                ",@stateId=4", sqlConn);
            cmd.Parameters.AddWithValue("@orderHeaderId", orderHeader.Id);
            //cmd.Parameters.AddWithValue("@stateId", orderHeader._orderState);
            sqlConn.Open();
            cmd.ExecuteNonQuery();

            sqlConn.Close();
        }
        /// <summary>
        /// Method for chaning order state from pending to rejected
        /// </summary>
        /// <param name="orderHeader"></param>
        public void UpdateOrderStatePendingtoRejected(OrderHeader orderHeader)
        {
            cmd = new SqlCommand("sp_UpdateOrderState @orderHeaderId " +
                ",@stateId=3", sqlConn);
            cmd.Parameters.AddWithValue("@orderHeaderId", orderHeader.Id);
            //cmd.Parameters.AddWithValue("@stateId", orderHeader._orderState);
            sqlConn.Open();
            cmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        /// <summary>
        /// Method for deleting a selected order header and all existing order items within by the order header Id
        /// </summary>
        /// <param name="orderHeaderId"></param>
        public void DeleteOrderHeaderAndOrderItems(int orderHeaderId)
        {
            cmd = new SqlCommand("sp_DeleteOrderHeaderAndOrderItems @orderHeaderId="
                + orderHeaderId, sqlConn);
            sqlConn.Open();
            cmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        /// <summary>
        /// Method for deleting a selected order item by stock item Id under a selected order header by order header Id
        /// </summary>
        /// <param name="orderHeaderId"></param>
        /// <param name="stockItemId"></param>
        public void DeleteOrderItem(int orderHeaderId, int stockItemId)
        {
            cmd = new SqlCommand("sp_DeleteOrderItem @orderHeaderId="
                + orderHeaderId + ",@stockItemId=" + stockItemId, sqlConn);
            sqlConn.Open();
            cmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        /// <summary>
        /// Method for selecting all stock items and return a StokItem type List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StockItem> GetStockItems()
        {
            List<StockItem> stockItems = new List<StockItem>();
            StockItem stockItem = null;
            cmd = new SqlCommand("sp_SelectStockItems", sqlConn);
            sqlConn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while(dataReader.Read())
                {
                    stockItem = new StockItem(dataReader.GetInt32(0), 
                        dataReader.GetString(1), 
                        dataReader.GetDecimal(2), 
                        dataReader.GetInt32(3));
                    //{
                    //    Id = dataReader.GetInt32(0),
                    //    Name = dataReader.GetString(1),
                    //    Price = dataReader.GetDecimal(2),
                    //    InStock = dataReader.GetInt32(3),
                    //};
                    //stockItem.Id = dataReader.GetInt32(0);
                    //stockItem.Name = dataReader.GetString(1);
                    //stockItem.Price = dataReader.GetDouble(2);
                    //stockItem.InStock = dataReader.GetInt32(3);
                    stockItems.Add(stockItem);
                }
                
            }

            sqlConn.Close();
            return stockItems;
        }

        /// <summary>
        /// Method for selecting a stock item by stock item Id and return a StockItem type variable
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StockItem GetStockItem(int id)
        {
            StockItem stockItem = null;
            cmd = new SqlCommand("sp_SelectStockItemById @id="
                + id, sqlConn);
            sqlConn.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();

            if(dataReader.HasRows)
            {
                while(dataReader.Read())
                {
                    stockItem = new StockItem(dataReader.GetInt32(0), dataReader.GetString(1),
                        dataReader.GetDecimal(2), dataReader.GetInt32(3));
                    //stockItem.Id = dataReader.GetInt32(0);
                    //stockItem.Name = dataReader.GetString(1);
                    //stockItem.Price = dataReader.GetDecimal(2);
                    //stockItem.InStock = dataReader.GetInt32(3);
                }
            }
            sqlConn.Close();

            return stockItem;
        }

        /// <summary>
        /// Method for reducing stock quantity of a selected item when the attached order header has been processed from pending to completed
        /// </summary>
        /// <param name="orderHeader"></param>
        public void UpdateStockItemAmount(OrderHeader orderHeader)
        {
            //int stokId = 0;
            //int orderQty = 0;

            //cmd = new SqlCommand("sp_SelectOrderHeaderById @id=" + orderHeader.Id, sqlConn);
            //sqlConn.Open();
            //SqlDataReader dataReader = cmd.ExecuteReader();

            //if (dataReader.HasRows)
            //{
            //    while (dataReader.Read())
            //    {
            //        // look for OrderItem
            //        int stockId = dataReader.GetInt32(3);
            //        int orderQty = dataReader.GetInt32(6);
                    
            //        cmd = new SqlCommand("sp_UpdateStockItemAmount @id=" + stockId +
            //            ",@amount=" + (-orderQty), sqlConn);
            //       /* cmd.Parameters.AddWithValue("@id", stockId);*/ //id should be ordered item stoc Id
            //        //cmd.Parameters.AddWithValue("@amount", (-orderQty));
            //    }
            //}
            sqlConn.Open();
            foreach (OrderItem orderItem in orderHeader._orderItems)
            {
                cmd = new SqlCommand("sp_UpdateStockItemAmount @id=" + orderItem.StockItemId
                    + ",@amount=" + (-(orderItem.Quantity)), sqlConn);
                cmd.ExecuteNonQuery();
            }
            sqlConn.Close();


            //sqlConn.Close();
        }

        //public void DecrementOrderStockItemAmount(OrderHeader order)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    using (var command = connection.CreateCommand())
        //    {
        //        connection.Open();
        //        var transaction = connection.BeginTransaction("UpdateStockAmountTransaction");
        //        command.Transaction = transaction;
        //        try
        //        {
        //            command.CommandText = "sp_UpdateStockItemAmount @id, @amount";
        //            foreach (var oi in order._orderItems)
        //            {
        //                command.Parameters.Add(new SqlParameter("@id", oi.StockItemId));
        //                command.Parameters.Add(new SqlParameter("@amount", -oi.Quantity));
        //                command.ExecuteNonQuery();
        //                command.Parameters.Clear();
        //            }
        //            transaction.Commit();
        //        }
        //        catch (SqlException ex)
        //        {
        //            transaction.Rollback();
        //            throw ex;
        //        }
        //    }
        //}
    }
}
