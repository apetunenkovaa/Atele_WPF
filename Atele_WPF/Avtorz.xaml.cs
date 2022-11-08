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

            Client autoUser = DataBase.tBE.Client.FirstOrDefault(x => x.Login == tb_Login.Text && x.Password == p);

            if (autoUser == null)  
            {
                MessageBox.Show("Пользователя не существует");
            }
            else
            {
                switch (autoUser.ID_Role)  
                {
                    case 1:  
                        FrameClass.MainFrame.Navigate(new AdminPage()); 
                        break;
                    case 2:  
                        MessageBox.Show("Привет, пользователь");
                        break;
                    default:
                        MessageBox.Show("Пока");
                        break;
                }
            }
        }
    }
}
