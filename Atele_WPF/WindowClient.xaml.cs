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
using System.Windows.Shapes;

namespace Atele_WPF
{
    /// <summary>
    /// Логика взаимодействия для WindowClient.xaml
    /// </summary>
    public partial class WindowClient : Window
    { 

        Client client;
        public WindowClient(Client client)
        {
            InitializeComponent();
            this.client = client; 
            tbName.Text = client.Firstname_Client;  
            tbSurname.Text = client.Surname_Client;  
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client.Firstname_Client = tbName.Text;
            client.Surname_Client = tbSurname.Text;  
            DataBase.tBE.SaveChanges();  
            this.Close();  
        }
        
    }
}
