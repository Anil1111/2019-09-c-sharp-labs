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

namespace Just_Do_It_12_Rabbit_Explosion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RealRabbit GrandPa;
        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            Initialise();
        }

        void Initialise()
        {
            GrandPa = new RealRabbit();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += TimerTicked;

            ImageRabbit.Visibility = Visibility.Hidden;

            PopulateListBox();
        }

        public void PopulateListBox()
        {
            listBox.Items.Clear();

            using (var db = new RabbitDbEntities())
            {
                List<Rabbit> rabbits = db.Rabbits.ToList();
                rabbits.ForEach(rabbit => listBox.Items.Add(rabbit.Name));
            }
        }

        public void TimerTicked(object sender, EventArgs e)
        {
            timer.Stop();
            ImageRabbit.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewRabbit();
        }

        public void AddNewRabbit()
        {
            try
            {
                string sAge = textBoxAge.GetLineText(0);
                string name = textBoxName.GetLineText(0);

                if (sAge.Length > 0 && name.Length > 0)
                {
                    AddNewRabbit(name, Int32.Parse(sAge));

                    ImageRabbit.Visibility = Visibility.Visible;
                    timer.Start();
                }
                else
                    MessageBox.Show("Both fields must be filled in");

            }
            catch
            {
                MessageBox.Show("Only numbers allowed in Age field");
            }
        }

        private void AddNewRabbit(string name, int age)
        {
            this.Title = "name";
            using (var db = new RabbitDbEntities())
            {
                List<Rabbit> rabbits = db.Rabbits.ToList();

                var newRabbit = new Rabbit()
                {
                    Age = age,
                    Name = $"{name}"
                };

                db.Rabbits.Add(newRabbit);
                db.SaveChanges();

                listBox.Items.Add(newRabbit.Name);
            }
        }
    }
}

    //<Grid >
    //    <Grid.ColumnDefinitions>
    //        <ColumnDefinition Width = "*" />
    //        < ColumnDefinition Width="*" />
    //        <ColumnDefinition Width = "*" />
    //    </ Grid.ColumnDefinitions >
    //    < Grid.RowDefinitions >
    //        < RowDefinition Height="*" />
    //        <RowDefinition Height = "*" />
    //        < RowDefinition Height="*" />
    //    </Grid.RowDefinitions>
    //    <Label Content = "Enter age:" Grid.Column="0" Grid.Row="0" HorizontalContentAlignment="Center" HorizontalAlignment="Left" VerticalContentAlignment="Center" VerticalAlignment="Top" Panel.ZIndex="10"/>
    //    <TextBox x:Name="textBoxName" Grid.Column="0" Grid.Row="0" Background="White" />
    //    <Button Content = "Button"  Grid.Column="2" Grid.Row="0"  />
    //</Grid>
