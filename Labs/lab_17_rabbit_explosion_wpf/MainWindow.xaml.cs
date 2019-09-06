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

namespace lab_17_rabbit_explosion_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();

            Initialise();
        }

        void Initialise()
        {
            Button01.Content = "Click Here";

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;

            Image01.Visibility = Visibility.Hidden;
        }

        private void DoChanges()
        {
            counter++;
            Button01.Content = $"{counter} times";

            Label01.Background = new SolidColorBrush(getRandomColour());
        }

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();

            Image01.Visibility = (Image01.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            DoChanges();
        }

        private Color getRandomColour()
        {
            Random r = new Random();
            return Color.FromArgb(
                            255,
                           (byte)(r.Next(0, 255) + 1),
                           (byte)(r.Next(0, 255) + 1),
                           (byte)(r.Next(0, 255) + 1));
        }


    }
}
