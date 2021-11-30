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
    /// Interaction logic for AddOrderViewWithLineItem.xaml
    /// </summary>
    public partial class AddOrderViewWithLineItem : Page
    {
        /*private */Repository _repo = new Repository();
        //OrderHeader orderHeader = null;
        //OrderHeader orderHeader = null;


        public AddOrderViewWithLineItem(Repository repo, OrderHeader orderHeader)
        {
            _repo = repo;
            InitializeComponent();
            //int id = (_repo.GetLastOrderHeader()).Id;
            //orderHeader = _repo.GetOrderHeader(id);
            this.DataContext = orderHeader;
            addOrder.ItemsSource = orderHeader._orderItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddOrderItemView(_repo, (OrderHeader)((Button)e.Source).DataContext));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _repo.UpdateOrderStateNewToPending(DataContext as OrderHeader);
            MessageBox.Show("Order successfully submitted for process");
            NavigationService.Navigate(new OrdersView(_repo)); // return OrdersView state changed to Pending
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int id = (DataContext as OrderHeader).Id;
            _repo.DeleteOrderHeaderAndOrderItems(id);
            MessageBox.Show("Order succesfully deleted");
            NavigationService.Navigate(new OrdersView(_repo)); // return OrdersView order cancelled
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
            //OrderHeader orderHeader = this.DataContext as OrderHeader; //001
            //addOrder.ItemsSource = orderHeader._orderItems; //001
            //int id = (addOrder.SelectedItem as OrderItem).OrderHeaderId; //001
            //int stockId = (addOrder.SelectedItem as OrderItem).StockItemId; //001
            //(addOrder.ItemsSource as List<OrderItem>).Remove(addOrder.SelectedItem as OrderItem);//001
            //(DataContext as OrderHeader)._orderItems.Remove(orderItem); //001
            //addOrder.ItemsSource = (DataContext as OrderHeader)._orderItems; //001

            OrderItem orderItem = addOrder.SelectedItem as OrderItem; //002
            int id = orderItem.OrderHeaderId; //002
            int stockId = orderItem.StockItemId; //002
            _repo.DeleteOrderItem(id, stockId);//002
            ((DataContext as OrderHeader)._orderItems).Remove(orderItem);//002

            MessageBox.Show("Ordered Item successfully deleted!");
            NavigationService.Navigate(new AddOrderViewWithLineItem(_repo, (DataContext as OrderHeader)));
        }
    }
}
