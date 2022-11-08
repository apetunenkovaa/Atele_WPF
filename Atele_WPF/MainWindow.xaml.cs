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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataBase.tBE = new Entities();
            FrameClass.MainFrame = fr_Main;
            FrameClass.MainFrame.Navigate(new MainPage());

        }

        private void bt_Auto_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new Avtorz());
        }

        private void bt_Reg_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new RegPage());
        }
    }
}

