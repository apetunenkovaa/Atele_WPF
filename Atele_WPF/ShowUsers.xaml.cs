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
    /// Логика взаимодействия для ShowUsers.xaml
    /// </summary>
    public partial class ShowUsers : Page
    {
        List<Client> client;

        public ShowUsers()
        {
            InitializeComponent();
            client = DataBase.tBE.Client.ToList();
            usersDG.ItemsSource = client;
            usersDG.SelectedValuePath = "ID_Client";

            fieldCB.SelectedIndex = 0;
            sortCB.SelectedIndex = 0;
            updateUsers();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateUsers();
        }

        void updateUsers()
        {
            client = DataBase.tBE.Client.ToList();
            switch (fieldCB.SelectedIndex)
            {
                case 0:
                    client = client.Where(x => x.Firstname_Client.Contains(searchTB.Text)).ToList();
                    break;
                case 1:
                    client = client.Where(x => x.Login.Contains(searchTB.Text)).ToList();
                    break;
            }
            switch (sortCB.SelectedIndex)
            {
                case 0:
                    client = client.OrderBy(x => x.Surname_Client).ToList();
                    break;
                case 1:
                    client = client.OrderByDescending(x => x.Surname_Client).ToList();
                    break;
            }
            usersDG.ItemsSource = client;
        }

        private void fieldCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateUsers();
        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateUsers();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            fieldCB.SelectedIndex = 0;
            sortCB.SelectedIndex = 0;
            searchTB.Text = "";
            updateUsers();
            client = DataBase.tBE.Client.ToList();
            usersDG.ItemsSource = client;
        }

        private void back_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (FrameClass.MainFrame.CanGoBack)
            {
                FrameClass.MainFrame.GoBack();
            }
        }
    }

   
}
