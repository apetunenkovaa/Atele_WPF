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

//логин и пароль для входа: логин - admin, пароль - 1234
namespace Atele_WPF
{
    /// <summary>
    /// Логика взаимодействия для Avtorz.xaml
    /// </summary>
    public partial class Avtorz : Page
    {
        public Avtorz()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int p = pb_Password.Password.GetHashCode();

            if (tb_Login.Text != "" && pb_Password.Password != "")
            {
                Client client = DataBase.tBE.Client.FirstOrDefault(x => x.Login == tb_Login.Text && x.Password == p);
          

                if (client == null)
                {
                    MessageBox.Show("Данный пользователь не зарегистрирован\nВведите верный логин и пароль");
                    tb_Login.Text = "";
                    pb_Password.Password = "";
                }
                else
                {
                    switch (client.ID_Role)
                    {
                        case 1:
                            FrameClass.MainFrame.Navigate(new AdminPage());
                            break;
                        case 2:
                            FrameClass.MainFrame.Navigate(new PersonalPage());
                            break;
                        default:
                            MessageBox.Show("Пока");
                            break;
                    }
                }
                

            }
            else
            {
                MessageBox.Show($"Не все поля заполнены");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new MainPage());
        }
    }
}
