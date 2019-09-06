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
using System.Windows.Threading;

namespace lab_18_rabbit_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Image Image01;

        int x = 0;


        RotateTransform rotateTransform = new RotateTransform(45);

        public MainWindow()
        {
            InitializeComponent();

            Initialise();
        }

        void Initialise()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timer_Tick;

            Image01 = new Image
            {
                Width = 100,
                Height = 100,
                Source = new BitmapImage(new Uri("Images/rabbit.png", UriKind.Relative)),
            };

            Image01.RenderTransform = rotateTransform;

            Canvas01.Children.Add(Image01);

            timer.Start();
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            x += 1;
            Canvas.SetLeft(Image01, x);
            Image01.RenderTransform = rotateTransform;
            rotateTransform.CenterX = 50;
            rotateTransform.CenterY = 50;
            rotateTransform.Angle += 6;
        }
    }
}


//"C:\\Users\\Fuat Kalay\\Documents\\My Projects\\github\\2019-09-c-sharp-labs\\Labs\\lab_18_rabbit_game\\Images\\rabbit.png"