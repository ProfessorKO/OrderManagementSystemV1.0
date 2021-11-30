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
    /// Interaction logic for OrdersView.xaml
    /// </summary>
    public partial class OrdersView : Page
    {
        Repository _repo = new Repository();
        //OrderHeader orderHeader = null;
        public OrdersView(Repository repo)
        {
            _repo = repo;
            InitializeComponent();
            orderHeaders.ItemsSource = _repo.GetOrderHeaders();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderDetailsView(_repo, (OrderHeader)((Button)e.Source).DataContext));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _repo.InsertOrderHearder();
            MessageBox.Show("New order header generated successfully!");
            NavigationService.Navigate(new AddOrderView(_repo, (OrderHeader)((Button)e.Source).DataContext)); // (_repo,orderHeader))
        }
    }
}
