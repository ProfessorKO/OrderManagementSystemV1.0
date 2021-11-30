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
    /// Interaction logic for AddOrderView.xaml
    /// </summary>
    public partial class AddOrderView : Page
    {
        Repository _repo = new Repository();
        //OrderHeader orderHeader = null;
        public AddOrderView(Repository repo, OrderHeader orderHeader)
        {
            _repo = repo;
            InitializeComponent();
            orderHeader = _repo.GetLastOrderHeader();
            this.DataContext = orderHeader;
            //dont leave it in the button declaration part
            if ((DataContext as OrderHeader)._orderItems.Count != 0)
            {
                BTN_Submit.Opacity = 1;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddOrderItemView(_repo, (OrderHeader)((Button)e.Source).DataContext));
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

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
            
        }

    }
}
