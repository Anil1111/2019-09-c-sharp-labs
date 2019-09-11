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

namespace lab_24_customers_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> listCustomers;
        List<Order> listOrders;
        List<Order_Detail> listOrderDetails;

        List<Order> tempOrders;

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            ShowPanel1();

            using (var db = new NorthwindEntities())
            {
                listCustomers = db.Customers.ToList();
                listOrders = db.Orders.ToList();
                listOrderDetails = db.Order_Details.ToList();

                ListBoxCustomers.ItemsSource = listCustomers;
            }
        }

        void ShowPanel1()
        {
            StackPanel01.Visibility = Visibility.Visible;
            StackPanel02.Visibility = Visibility.Collapsed;
            StackPanel03.Visibility = Visibility.Collapsed;
        }
        void ShowPanel2()
        {
            StackPanel01.Visibility = Visibility.Collapsed;
            StackPanel02.Visibility = Visibility.Visible;
            StackPanel03.Visibility = Visibility.Collapsed;
        }

        void ShowPanel3()
        {
            StackPanel01.Visibility = Visibility.Collapsed;
            StackPanel02.Visibility = Visibility.Collapsed;
            StackPanel03.Visibility = Visibility.Visible;
        }

        List<Customer> searchForCustomer(string name, string city)
        {
            return listCustomers.Where(c => c.ContactName.ToLower().Contains(name.ToLower()) && c.City.ToLower().Contains(city.ToLower())).ToList();
        }

        List<Customer> searchByName(string searchString)
        {
            return listCustomers.Where(c => c.ContactName.ToLower().Contains(searchString.ToLower())).ToList();
        }

        List<Customer> searchByCity(string searchString)
        {
            return listCustomers.Where(c => c.City.ToLower().Contains(searchString.ToLower())).ToList();
        }

        List<Order> searchForOrdersByOrderID(string searchString)
        {
            return tempOrders.Where(o => o.OrderID.ToString().Contains(searchString)).ToList();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanel01.Visibility == Visibility.Visible)
            {
                ShowPanel3();
            }
            else if (StackPanel02.Visibility == Visibility.Visible)
            {
                ShowPanel1();
            }
            else if (StackPanel03.Visibility == Visibility.Visible)
            {
                ShowPanel2();
            }
        }

        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanel01.Visibility == Visibility.Visible)
            {
                ShowPanel2();
            }
            else if (StackPanel02.Visibility == Visibility.Visible)
            {
                ShowPanel3();
            }
            else if (StackPanel03.Visibility == Visibility.Visible)
            {
                ShowPanel1();
            }
        }

        private void CustomerNameFilter_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CustomerSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //ListBoxCustomers.ItemsSource = searchByName(CustomerSearch.Text);
            ListBoxCustomers.ItemsSource = searchForCustomer(CustomerSearch.Text, CitySearch.Text);
        }

        private void CitySearch_KeyUp(object sender, KeyEventArgs e)
        {
            //ListBoxCustomers.ItemsSource = searchByCity(CitySearch.Text);
            ListBoxCustomers.ItemsSource = searchForCustomer(CustomerSearch.Text, CitySearch.Text);
        }

        private void OrderIDSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ListBoxOrders.ItemsSource = searchForOrdersByOrderID(OrderIDSearch.Text);
        }

        private void ListBoxCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowOrdersPanel((Customer)ListBoxCustomers.SelectedItem);
        }

        private void ListBoxOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowProductsPanel((Order)ListBoxOrders.SelectedItem);
        }

        void ShowOrdersPanel(Customer customer)
        {
            ShowPanel2();

            tempOrders = listOrders.Where(o => o.CustomerID == customer.CustomerID).ToList();
            ListBoxOrders.ItemsSource = tempOrders;
        }

        void ShowProductsPanel(Order order)
        {
            ShowPanel3();

            ListBoxProductsOrdered.ItemsSource = listOrderDetails.Where(o => o.OrderID == order.OrderID).ToList();
        }
    }
}


/*
      
    <Grid.Resources>
        <ImageBrush x:Key="BackButtonImage" ImageSource="/lab_24_customers_app;component/bb.png" Stretch="UniformToFill"/>
        <ImageBrush x:Key="ForwardButtonImage" ImageSource="/lab_24_customers_app;component/ff.png" Stretch="UniformToFill"/>
    </Grid.Resources>
*/
/*
    <Button x:Name="ButtonBack" Grid.Column="1" Grid.Row="4" FontWeight="Bold" FontSize="20" Click="ButtonBack_Click"  Background="{StaticResource BackButtonImage}"/>
    <Button x:Name="ButtonForward"  Grid.Column="3" Grid.Row="4" FontWeight="Bold" FontSize="20" Click="ButtonForward_Click"  Background="{StaticResource ForwardButtonImage}"/>

    */

/*

    <Button x:Name="ButtonBack" Content="Back" Background="#547DF0" Grid.Column="1" Grid.Row="4" FontWeight="Bold" FontSize="20" Click="ButtonBack_Click" />
    <Button x:Name="ButtonForward" Content="Forward" Background="#547DF0" Grid.Column="3" Grid.Row="4" FontWeight="Bold" FontSize="20" Click="ButtonForward_Click"/>
*/