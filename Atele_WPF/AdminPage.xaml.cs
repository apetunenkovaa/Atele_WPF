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

namespace Atele_WPF
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        Client client;
        public AdminPage(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

       
        private void showUsersBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new ShowUsers());
        }

        private void addNewOrder_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new orders());
        }

        private void showOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new ShowOrders());
        }

        private void goToPersonalPage_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new PersonalPage(client));
        }
    }
}
