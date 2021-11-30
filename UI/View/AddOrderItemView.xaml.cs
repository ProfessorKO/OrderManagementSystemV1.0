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
    /// Interaction logic for AddOrderItemView.xaml
    /// </summary>
    public partial class AddOrderItemView : Page
    {
        private Repository _repo = new Repository();
        //private OrderHeader orderHeader = null;
        private StockItem stockItem = null;
        //private OrderItem orderItem = null;
        public AddOrderItemView(Repository repo, OrderHeader orderHeader)
        {
            _repo = repo;
            InitializeComponent();
            this.DataContext = orderHeader;
            stockItems.ItemsSource = _repo.GetStockItems();

        }

        //double click to select line item
        //private void Row_SingleClick(object sender, MouseButtonEventArgs e)
        //{
        //    stockItem = stockItems.SelectedItem as StockItem;
        //    MessageBox.Show("This item has been selected");
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //when cliking insertOrderHeader->GetStockItem(int id)
            //->UpsertOrderItem(assign quantity input to
            //OrderItem(..Quantity) / also needs to 
            // select line item
            stockItem = stockItems.SelectedItem as StockItem;

            if (int.Parse(itemQuantity.Text) <= 0)
            {
                MessageBox.Show("Please ensure quantity is greater than 0");
            }
            else if (int.Parse(itemQuantity.Text) > 0)
            {
                if(stockItem == null)
                {
                    MessageBox.Show("Please ensure line item is selected");
                }
                else if(stockItem != null)
                {
                    //OrderHeader orderHeader = _repo.GetLastOrderHeader();
                    //int id = orderHeader.Id;

                    if (int.Parse(itemQuantity.Text) > stockItem.InStock)
                    {
                        MessageBox.Show("The order amount exceed the stock amount." +
                        " The order might get rejected.");

                        OrderItem orderItem = new OrderItem((DataContext as OrderHeader),
                            (DataContext as OrderHeader).Id, stockItem.Id, stockItem.Name,
                            stockItem.Price, int.Parse(itemQuantity.Text));
                        _repo.UpsertOrderItem(orderItem);
                        (DataContext as OrderHeader).UpdateOrderItem((DataContext as OrderHeader).Id,
                            stockItem.Id, stockItem.Name,
                            stockItem.Price, int.Parse(itemQuantity.Text));

                        MessageBox.Show("Item Added Successfully!");
                        NavigationService.Navigate(new AddOrderViewWithLineItem(_repo, (OrderHeader)((Button)e.Source).DataContext));
                    }
                    else if (int.Parse(itemQuantity.Text) <= stockItem.InStock)
                    {
                        OrderItem orderItem = new OrderItem((DataContext as OrderHeader),
                            (DataContext as OrderHeader).Id, stockItem.Id, stockItem.Name,
                            stockItem.Price, int.Parse(itemQuantity.Text));
                        _repo.UpsertOrderItem(orderItem);
                        (DataContext as OrderHeader).UpdateOrderItem((DataContext as OrderHeader).Id,
                            stockItem.Id, stockItem.Name,
                            stockItem.Price, int.Parse(itemQuantity.Text));

                        MessageBox.Show("Item Added Successfully!");
                        NavigationService.Navigate(new AddOrderViewWithLineItem(_repo, (OrderHeader)((Button)e.Source).DataContext));
                    }
                }
                
            }  
        }

        
    }
}
