using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        
        public MainPage()
        {
            InitializeComponent();
            DoubleAnimation WA = new DoubleAnimation(); 
            WA.From = 0; 
            WA.To = 30; 
            WA.Duration = TimeSpan.FromSeconds(2); 
            WA.RepeatBehavior = RepeatBehavior.Forever;
            WA.AutoReverse = true; 
            btnp1.BeginAnimation(HeightProperty, WA);
            btnp2.BeginAnimation(HeightProperty, WA);

            ThicknessAnimation MA = new ThicknessAnimation(); 
            MA.From = new Thickness(60, 0, 60, 60);
            MA.To = new Thickness(0, 0, 0, 0);
            MA.Duration = TimeSpan.FromSeconds(2);
            MA.AutoReverse = true;
            btnp1.BeginAnimation(MarginProperty, MA);
            btnp2.BeginAnimation(MarginProperty, MA);



            DoubleAnimation FSA = new DoubleAnimation();
            FSA.From = 15;
            FSA.To = 20;
            FSA.Duration = TimeSpan.FromSeconds(2);
            FSA.RepeatBehavior = RepeatBehavior.Forever;
            FSA.AutoReverse = true;
            tb_text.BeginAnimation(FontSizeProperty, FSA);

            ColorAnimation BA = new ColorAnimation();
            Color Cstart = Color.FromRgb(0,0,0);
            tb_text.Foreground = new SolidColorBrush(Cstart);
            BA.From = Cstart;
            BA.To = Color.FromRgb(255, 255, 255);
            BA.Duration = TimeSpan.FromSeconds(3);
            BA.RepeatBehavior = RepeatBehavior.Forever;
            BA.AutoReverse = true;
            tb_text.Foreground.BeginAnimation(SolidColorBrush.ColorProperty, BA);

            DoubleAnimation Wh = new DoubleAnimation();
            Wh.From = 100; 
            Wh.To =250; 
            Wh.Duration = TimeSpan.FromSeconds(3); 
            Wh.RepeatBehavior = RepeatBehavior.Forever;
            Wh.AutoReverse = true; 
            Photo.BeginAnimation(WidthProperty, Wh); 


        }



    }
}
