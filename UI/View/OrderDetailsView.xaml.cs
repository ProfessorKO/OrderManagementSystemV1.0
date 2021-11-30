using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domain;
using DataAccess;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for OrderDetailsView.xaml
    /// </summary>
    public partial class OrderDetailsView : Page
    {
        Repository _repo = new Repository();
        //OrderHeader orderHeader = null;
        public OrderDetailsView(Repository repo, OrderHeader orderHeader)
        {
            _repo = repo;
            InitializeComponent();
            this.DataContext = orderHeader;
            orderDetails.ItemsSource = orderHeader._orderItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrdersView(_repo));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //OrderHeader orderHeader = null;
            //this.DataContext = orderHeader;
            int ctr = 0;
            foreach (OrderItem orderItem in (DataContext as OrderHeader)._orderItems)
            {
                int stockId = orderItem.StockItemId;
                StockItem stockItem = _repo.GetStockItem(stockId);
               
                if (orderItem.Quantity <= stockItem.InStock)
                {
                    ctr += 0;
                }
                else if (orderItem.Quantity > stockItem.InStock)
                {
                    ctr += 1;
                }
            }

            if(ctr != 0 )
            {
                MessageBox.Show("Order Rejected due to one of the ordered item has stock smaller than ordered quantity!");
                _repo.UpdateOrderStatePendingtoRejected(DataContext as OrderHeader);

            }
            else if(ctr ==0)
            {
                MessageBox.Show("Order Completed!");
                _repo.UpdateOrderStatePendingToCompleted(DataContext as OrderHeader);
                _repo.UpdateStockItemAmount(DataContext as OrderHeader);
            }
            
            NavigationService.Navigate(new OrdersView(_repo)); /* also bring user back to order view but state will change from pendingg to either complete or rejected depends on the stock availability*/

        }
    }
}
