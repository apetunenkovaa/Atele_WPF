using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    /// Логика взаимодействия для PersonalPage.xaml
    /// </summary>
    public partial class PersonalPage : Page
    {
        Client client;

        void showImage(byte[] Barray, System.Windows.Controls.Image img)
        {
            BitmapImage BI = new BitmapImage();  
            using (MemoryStream m = new MemoryStream(Barray))  
            {
                BI.BeginInit(); 
                BI.StreamSource = m;  
                BI.CacheOption = BitmapCacheOption.OnLoad;  
                BI.EndInit();  
            }
            img.Source = BI;  
            img.Stretch = Stretch.Uniform;
        }

        public PersonalPage(Client client)
        {
            InitializeComponent();
            this.client = client;  
            tbName.Text = client.Firstname_Client;  
            tbSurname.Text = client.Surname_Client; 
            List<Client_photo> u = DataBase.tBE.Client_photo.Where(x => x.ID_Client == client.ID_Client).ToList(); 
            if (u.Count != 0)  
            {

                byte[] Bar = u[u.Count - 1].Photo_binary;   
                showImage(Bar, imgClient);  
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)  
        {
            WindowClient windowclient = new WindowClient(client);  
            windowclient.ShowDialog(); 
            FrameClass.MainFrame.Navigate(new PersonalPage(client));  


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Client_photo c = new Client_photo();  
                c.ID_Client = client.ID_Client;  

                OpenFileDialog OFD = new OpenFileDialog(); 
                //OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);  
                OFD.ShowDialog();               
                string path = OFD.FileName; 
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);  
                ImageConverter IC = new ImageConverter();  
                byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));  
                c.Photo_binary = Barray;  
                DataBase.tBE.Client_photo.Add(c);  
                DataBase.tBE.SaveChanges();  
                MessageBox.Show("Фото добавлено");
                FrameClass.MainFrame.Navigate(new PersonalPage(client)); 

            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();  
                OFD.Multiselect = true;  
                if (OFD.ShowDialog() == true)  
                {
                    foreach (string file in OFD.FileNames)  
                    {
                        Client_photo c = new Client_photo(); 
                        c.ID_Client = client.ID_Client;  
                        string path = file;  
                        System.Drawing.Image SDI = System.Drawing.Image.FromFile(file);  
                        ImageConverter IC = new ImageConverter(); 
                        byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[])); 
                        c.Photo_binary = Barray;  
                        DataBase.tBE.Client_photo.Add(c); 
                    }
                    DataBase.tBE.SaveChanges();
                    MessageBox.Show("Фото добавлены");
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        int n = 0;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            spGallery.Visibility = Visibility.Visible;
            List<Client_photo> c = DataBase.tBE.Client_photo.Where(x => x.ID_Client == client.ID_Client).ToList();
            if (c != null)  
            {

                byte[] Bar = c[n].Photo_binary;   
                showImage(Bar, imgGallery);  
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            List<Client_photo> c = DataBase.tBE.Client_photo.Where(x => x.ID_Client == client.ID_Client).ToList();
            n++;
            if (c != null)
            {

                byte[] Bar = c[n].Photo_binary;
                showImage(Bar, imgGallery);
            }
            if (n == c.Count - 1)
            {
                n = -1;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            List<Client_photo> c = DataBase.tBE.Client_photo.Where(x => x.ID_Client == client.ID_Client).ToList();
            if (c != null)
            {
                if (n == 0)
                {
                    n = c.Count;
                }
                if (n == -1)
                {
                    n = c.Count - 1;
                }
                n--;
                byte[] Bar = c[n].Photo_binary;
                BitmapImage BI = new BitmapImage();
                showImage(Bar, imgGallery);
            }
        }

        private void btnOld_Click(object sender, RoutedEventArgs e)
        {
            List<Client_photo> c = DataBase.tBE.Client_photo.Where(x => x.ID_Client == client.ID_Client).ToList();
            byte[] Bar = c[n].Photo_binary;   
            showImage(Bar, imgClient);
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new AdminPage(client));
        }
    }

}

