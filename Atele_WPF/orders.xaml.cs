using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations.Model;
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
    /// Логика взаимодействия для orders.xaml
    /// </summary>
    public partial class orders : Page
    {
        bool flagUpdate;
        Client client;

        void uploadFields()
        {
            List<Client> client = DataBase.tBE.Client.ToList();

            clientsCB.ItemsSource = client;
            clientsCB.SelectedValuePath = "ID_Client";
            clientsCB.DisplayMemberPath = "Surname_Client";

            sotrudnicCB.ItemsSource = DataBase.tBE.Sotrudnic.ToList();
            sotrudnicCB.SelectedValuePath = "ID_Sotrudnic";
            sotrudnicCB.DisplayMemberPath = "Surname_sotrudnic";

            workCB.ItemsSource = DataBase.tBE.Work.ToList();
            workCB.SelectedValuePath = "ID_Work";
            workCB.DisplayMemberPath = "Name_work";

            measurementsLV.ItemsSource = DataBase.tBE.Measurement.ToList();

            basic_materialsLV.ItemsSource = DataBase.tBE.Basic_material.ToList();

            accesoriesLV.ItemsSource = DataBase.tBE.Accessory.ToList();
        }

        public orders()
        {
            InitializeComponent();
            uploadFields();
            flagUpdate = false;
            addBTN.Content = "Добавить";
        }

        Order order;

        public orders(Order order)
        {
            InitializeComponent();
            uploadFields();
            flagUpdate = true;
            addBTN.Content = "Изменить";

            this.order = order;
            clientsCB.SelectedValue = order.Client.ID_Client;
            sotrudnicCB.SelectedValue = order.Sotrudnic.ID_Sotrudnic;
            workCB.SelectedValue = order.Work.ID_Work;

            List<Order_Accessory> accessories = DataBase.tBE.Order_Accessory.Where(x => x.ID_Order == order.ID_Order).ToList();
            foreach (Accessory item in accesoriesLV.Items)
            {
                if (accessories.FirstOrDefault(x => x.ID_Accessory == item.ID_Accessory) != null)
                {
                    accesoriesLV.SelectedItems.Add(item);
                }
            }

            List<Order_basic_material> materials = DataBase.tBE.Order_basic_material.Where(x => x.ID_Order == order.ID_Order).ToList();
            foreach (Basic_material item in basic_materialsLV.Items)
            {
                if (materials.FirstOrDefault(x => x.ID_Basic_material == item.ID_Basic_material) != null)
                {
                    item.BM = Convert.ToInt32(materials.FirstOrDefault(x => x.ID_Basic_material == item.ID_Basic_material).Quantity_Basic_material);
                }
            }

            List<Order_measurement> measurements = DataBase.tBE.Order_measurement.Where(x => x.ID_Order == order.ID_Order).ToList();
            foreach (Measurement item in measurementsLV.Items)
            {
                if (measurements.FirstOrDefault(x => x.ID_Measurement == item.ID_Measurement) != null)
                {
                    item.MT = Convert.ToInt32(measurements.FirstOrDefault(x => x.ID_Measurement == item.ID_Measurement).Size);
                }
            }
        }

        private void clientsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                MessageBox.Show(clientsCB.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (flagUpdate)
                {
                    order.ID_Client = Convert.ToInt32(clientsCB.SelectedValue);
                    order.ID_Sotrudnic = Convert.ToInt32(sotrudnicCB.SelectedValue);
                    order.ID_Work = Convert.ToInt32(workCB.SelectedValue);

                    List<Order_Accessory> accessories = DataBase.tBE.Order_Accessory.Where(x => x.ID_Order == order.ID_Order).ToList();
                    if (accessories.Count > 0)
                    {
                        foreach (Order_Accessory item in accessories)
                        {
                            DataBase.tBE.Order_Accessory.Remove(item);
                        }
                    }

                    foreach (Accessory item in accesoriesLV.SelectedItems)
                    {
                        Order_Accessory a = new Order_Accessory()
                        {
                            ID_Order = order.ID_Order,
                            ID_Accessory = item.ID_Accessory
                        };
                        DataBase.tBE.Order_Accessory.Add(a);
                    }

                    List<Order_basic_material> materials = DataBase.tBE.Order_basic_material.Where(x => x.ID_Order == order.ID_Order).ToList();
                    if (materials.Count > 0)
                    {
                        foreach (Order_basic_material item in materials)
                        {
                            DataBase.tBE.Order_basic_material.Remove(item);
                        }
                    }
                    foreach (Basic_material item in basic_materialsLV.Items)
                    {
                        if (item.BM > 0)
                        {
                            Order_basic_material obm = new Order_basic_material()
                            {
                                ID_Order = order.ID_Order,
                                ID_Basic_material = item.ID_Basic_material,
                                Quantity_Basic_material = item.BM
                            };
                            DataBase.tBE.Order_basic_material.Add(obm);
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
                    foreach (Measurement item in measurementsLV.Items)
                    {
                        if (item.MT > 0)
                        {
                            Order_measurement om = new Order_measurement()
                            {
                                ID_Order = order.ID_Order,
                                ID_Measurement = item.ID_Measurement,
                                Size = item.MT
                            };
                            DataBase.tBE.Order_measurement.Add(om);
                        }
                    }

                    DataBase.tBE.SaveChanges();
                    MessageBox.Show("Изменения внесены");
                    FrameClass.MainFrame.Navigate(new ShowOrders());
                }
                else
                {
                    order = new Order();

                    order.ID_Client = Convert.ToInt32(clientsCB.SelectedValue);
                    order.ID_Sotrudnic = Convert.ToInt32(sotrudnicCB.SelectedValue);
                    order.ID_Work = Convert.ToInt32(workCB.SelectedValue);

                    DataBase.tBE.Order.Add(order);

                    foreach (Measurement item in measurementsLV.Items)
                    {
                        if (item.MT > 0)
                        {
                            Order_measurement om = new Order_measurement()
                            {
                                ID_Order = order.ID_Order,
                                ID_Measurement = item.ID_Measurement,
                                Size = item.MT
                            };
                            DataBase.tBE.Order_measurement.Add(om);
                        }
                    }

                    foreach (Basic_material item in basic_materialsLV.Items)
                    {
                        if (item.BM > 0)
                        {
                            Order_basic_material obm = new Order_basic_material()
                            {
                                ID_Order = order.ID_Order,
                                ID_Basic_material = item.ID_Basic_material,
                                Quantity_Basic_material = item.BM
                            };
                            DataBase.tBE.Order_basic_material.Add(obm);
                        }
                    }

                    foreach (Accessory item in accesoriesLV.SelectedItems)
                    {
                        Order_Accessory oa = new Order_Accessory()
                        {
                            ID_Order = order.ID_Order,
                            ID_Accessory = item.ID_Accessory
                        };
                        DataBase.tBE.Order_Accessory.Add(oa);
                    }

                    DataBase.tBE.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                    FrameClass.MainFrame.Navigate(new AdminPage(client));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backBTN_Click(object sender, RoutedEventArgs e)
        {
            if (FrameClass.MainFrame.CanGoBack)
            {
                FrameClass.MainFrame.GoBack();
            }
        }
    }
}
