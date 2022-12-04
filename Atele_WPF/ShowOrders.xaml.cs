using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Логика взаимодействия для ShowOrders.xaml
    /// </summary>
    public partial class ShowOrders : Page
    {
        Client client;
        public ShowOrders()
        {
            InitializeComponent();
            ordersLV.ItemsSource = DataBase.tBE.Order.ToList();
        }

        private void clientNameTB_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);

            Order order = DataBase.tBE.Order.FirstOrDefault(x => x.ID_Order == index);

            tb.Text = $"Клиент: {order.Client.Surname_Client} {order.Client.Firstname_Client} {order.Client.Patronymic_Client}";

        }

        private void orderIdTB_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);
            Order order = DataBase.tBE.Order.FirstOrDefault(x => x.ID_Order == index);

            (sender as TextBlock).Text = $"Заказ №{order.ID_Order}";
        }

        private void sotrudnicNameTB_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);
            Order order = DataBase.tBE.Order.FirstOrDefault(x => x.ID_Order == index);

            (sender as TextBlock).Text = $"Сотрудник: {order.Sotrudnic.Surname_sotrudnic} {order.Sotrudnic.Firstname_sotrudnic} {order.Sotrudnic.Patronymic_sotrudnic}";
        }

        private void AccesoriesTB_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);
            List<Order_Accessory> accessories = DataBase.tBE.Order_Accessory.Where(x => x.ID_Order == index).ToList();

            if(accessories.Count > 0)
            {
                string str = "";

                foreach (Order_Accessory item in accessories)
                {
                    str += item.Accessory.Name_accessory + ", ";
                }

                (sender as TextBlock).Text = "Аксессуары: " + str.Substring(0, str.Length - 2);
            }
            else
            {
                (sender as TextBlock).Text = "Аксессуары: -";
            }
        }

        private void materialsTB_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);
            List<Order_basic_material> materials = DataBase.tBE.Order_basic_material.Where(x => x.ID_Order == index).ToList();

            if(materials.Count > 0)
            {
                string str = "";

                foreach (Order_basic_material item in materials)
                {
                    str += $"{item.Basic_material.Name_basic_material}({item.Quantity_Basic_material}), ";
                }

                (sender as TextBlock).Text = "Материалы: " + str.Substring(0, str.Length - 2);
            }
            else
            {
                (sender as TextBlock).Text = "Материалы: -";
            }
        }

        private void measurementsTB_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);
            List<Order_measurement> measurements = DataBase.tBE.Order_measurement.Where(x => x.ID_Order == index).ToList();

            if (measurements.Count > 0)
            {
                string str = "";

                foreach (Order_measurement item in measurements)
                {
                    str += $"{item.Measurement.Name_measurement}({item.Size}), ";
                }

                (sender as TextBlock).Text = "Мерки: " + str.Substring(0, str.Length - 2);
            }
            else
            {
                (sender as TextBlock).Text = "Мерки: -";
            }
        }

        private void updateBTN_Click(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as Button).Uid);
            Order order = DataBase.tBE.Order.FirstOrDefault(x => x.ID_Order == index);
            FrameClass.MainFrame.Navigate(new orders(order));
        }

        private void deleteBTN_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Уверены, что хотите удалить запись", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                int index = Convert.ToInt32((sender as Button).Uid);
                Order order = DataBase.tBE.Order.FirstOrDefault(x => x.ID_Order == index);

                List<Order_Accessory> accessories = DataBase.tBE.Order_Accessory.Where(x => x.ID_Order == order.ID_Order).ToList();
                if (accessories.Count > 0)
                {
                    foreach (Order_Accessory item in accessories)
                    {
                        DataBase.tBE.Order_Accessory.Remove(item);
                    }
                }

                List<Order_basic_material> materials = DataBase.tBE.Order_basic_material.Where(x => x.ID_Order == order.ID_Order).ToList();
                if (materials.Count > 0)
                {
                    foreach (Order_basic_material item in materials)
                    {
                        DataBase.tBE.Order_basic_material.Remove(item);
                    }
                }

                List<Order_measurement> measurements = DataBase.tBE.Order_measurement.Where(x => x.ID_Order == order.ID_Order).ToList();
                if (measurements.Count > 0)
                {
                    foreach (Order_measurement item in measurements)
                    {
                        DataBase.tBE.Order_measurement.Remove(item);
                    }
                }

                DataBase.tBE.Order.Remove(order);
                DataBase.tBE.SaveChanges();
                MessageBox.Show("Запись удалена");
                FrameClass.MainFrame.Navigate(new ShowOrders());
            }
        }

        private void backBTN_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new AdminPage(client));
        }
    }
}
