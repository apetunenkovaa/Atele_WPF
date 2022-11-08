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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            cb_Role.ItemsSource = DataBase.tBE.Role.ToList();
            cb_Role.SelectedValuePath = "ID_Role";
            cb_Role.DisplayMemberPath = "Role1";
            cb_Role.SelectedIndex = 1;
        }

        private void bt_Registation_Click(object sender, RoutedEventArgs e)
        {

            Client client = new Client()
            {
                Surname_Client = tbx_Surname.Text,
                Firstname_Client = tbx_Firstname.Text,
                Patronymic_Client = tbx_Patronymic.Text,
                Adress = tbx_Adress.Text,
                Mobile_phone = tbx_Mobile_phone.Text,
                Email = tbx_Email.Text,
                Login = tbx_Login.Text,
                Password = pb_Password.Password.GetHashCode(),
                ID_Role = cb_Role.SelectedIndex + 1
            };
            DataBase.tBE.Client.Add(client);
            DataBase.tBE.SaveChanges();  
            MessageBox.Show("Пользователь добавлен");
            FrameClass.MainFrame.Navigate(new MainPage());
        }
    }
}
