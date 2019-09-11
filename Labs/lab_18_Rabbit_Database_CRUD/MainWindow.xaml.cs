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

namespace lab_18_Rabbit_Database_CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Rabbit> rabbits;
        static Rabbit rabbit = new Rabbit();

        static SolidColorBrush ReadOnlyBrush = (SolidColorBrush)Brushes.Wheat;
        static SolidColorBrush EditableBrush = (SolidColorBrush)Brushes.White;
        static SolidColorBrush ButtonsFirstMode = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EE4540"));
        static SolidColorBrush ButtonsSecondMode = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8000"));

        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            EnterSelectingMode();

            //using : automatice clean-up when block is done
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }

            //Fancy 'lamba' to a) loop rabbits b) each loop, add item to listbox
            //  rabbits.ForEach(element => ListBoxRabbits.Items.Add(element.Name));

            //'Binding'
            ListBoxRabbits.DisplayMemberPath = "Name";
            ListBoxRabbits.ItemsSource = rabbits;
        }

        private void EnterSelectingMode()
        {
            ButtonAdd.Content = "Add";
            ButtonEdit.Content = "Edit";
            ButtonDelete.Content = "Delete";

            ButtonAdd.IsEnabled = true;
            ButtonEdit.IsEnabled = false;
            ButtonDelete.IsEnabled = false;
            ListBoxRabbits.IsEnabled = true;

            TextBoxName.IsReadOnly = true;
            TextBoxAge.IsReadOnly = true;

            TextBoxName.Background = ReadOnlyBrush;
            TextBoxAge.Background = ReadOnlyBrush;

            ButtonAdd.Background = ButtonsFirstMode;
            ButtonEdit.Background = ButtonsFirstMode;
            ButtonDelete.Background = ButtonsFirstMode;
        }

        private void EnterAddSaveMode()
        {
            ButtonAdd.Content = "Save";
            ButtonAdd.Background = ButtonsSecondMode;

            ButtonEdit.Background = ButtonsFirstMode;
            ButtonDelete.Background = ButtonsFirstMode;

            TextBoxName.Background = EditableBrush;
            TextBoxAge.Background = EditableBrush;

            TextBoxName.IsReadOnly = false;
            TextBoxAge.IsReadOnly = false;

            ButtonAdd.IsEnabled = true;
            ButtonEdit.IsEnabled = false;
            ButtonDelete.IsEnabled = false;

            ListBoxRabbits.IsEnabled = false;

            TextBoxName.Text = "";
            TextBoxAge.Text = "";
        }

        private void EnterEditSaveMode()
        {
            ButtonEdit.Content = "Save";
            ButtonEdit.Background = ButtonsSecondMode;

            ButtonAdd.Background = ButtonsFirstMode;
            ButtonDelete.Background = ButtonsFirstMode;

            TextBoxName.Background = EditableBrush;
            TextBoxAge.Background = EditableBrush;

            TextBoxName.IsReadOnly = false;
            TextBoxAge.IsReadOnly = false;

            ButtonAdd.IsEnabled = false;
            ButtonEdit.IsEnabled = true;
            ButtonDelete.IsEnabled = true;

            TextBoxName.Focus();
            TextBoxName.SelectAll();
        }

        private void EnterDeleteMode()
        {
            ButtonDelete.Content = "Confirm Delete?";
            ButtonDelete.Background = ButtonsSecondMode;

            //ButtonAdd.Background = ButtonsFirstMode;
            //ButtonEdit.Background = ButtonsFirstMode;

            //TextBoxName.Background = EditableBrush;
            //TextBoxAge.Background = EditableBrush;

            //TextBoxName.IsReadOnly = false;
            //TextBoxAge.IsReadOnly = false;

            //ButtonAdd.IsEnabled = false;
            //ButtonEdit.IsEnabled = true;
            //ButtonDelete.IsEnabled = true;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.Key.ToString());
        }

        private void UpdateRabbitsListBox(List<Rabbit> list)
        {
            ListBoxRabbits.ItemsSource = null;
            ListBoxRabbits.Items.Clear();
            rabbits = list;
            ListBoxRabbits.ItemsSource = rabbits;
        }

        private void ListBoxRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxRabbits.SelectedItem != null)
            {
                rabbit = (Rabbit)ListBoxRabbits.SelectedItem;
                TextBoxName.Text = rabbit.Name;
                TextBoxAge.Text = rabbit.Age.ToString();

                //enable edit and delete
                ButtonEdit.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonAdd.Content.Equals("Add"))
            {
                EnterAddSaveMode();
            }
            else
            {
                EnterSelectingMode();

                if ((TextBoxAge.Text.Length > 0) && (TextBoxName.Text.Length > 0))
                {
                    if (int.TryParse(TextBoxAge.Text, out int age))
                    {
                        var RabbitToAdd = new Rabbit()
                        {
                            Name = TextBoxName.Text,
                            Age = age
                        };

                        //read db and add new rabbit
                        using (var db = new RabbitDbEntities())
                        {
                            db.Rabbits.Add(RabbitToAdd);
                            db.SaveChanges();

                            rabbit = null;
                            rabbits = db.Rabbits.ToList();
                            ListBoxRabbits.ItemsSource = rabbits;
                        }
                    }
                }
            }
        }
  
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if(ButtonEdit.Content.Equals("Edit"))
            {
                EnterEditSaveMode();
            }
            else
            {
                EnterSelectingMode();

                if((TextBoxAge.Text.Length > 0) && (TextBoxName.Text.Length > 0))
                {
                    if (rabbit != null)
                    {
                        rabbit.Name = TextBoxName.Text;
                        if (int.TryParse(TextBoxAge.Text, out int age))
                            rabbit.Age = age;

                        using (var db = new RabbitDbEntities())
                        {
                            //read rabbit from database by ID
                            var rabbitToUpdate = db.Rabbits.Find(rabbit.RabbitId);

                            //update rabbit
                            rabbitToUpdate.Name = rabbit.Name;
                            rabbitToUpdate.Age = rabbit.Age;

                            //save rabbit back to DB
                            db.SaveChanges();

                            //repopulate listbox
                            UpdateRabbitsListBox(db.Rabbits.ToList());
                        }
                    }
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.Equals("Delete"))
            {
                EnterDeleteMode();
            }
            else
            {
                EnterSelectingMode();

                if(rabbit != null)
                {
                    using (var db = new RabbitDbEntities())
                    {
                        var rabbitToDelete = db.Rabbits.Find(rabbit.RabbitId);

                        db.Rabbits.Remove(rabbitToDelete);
                        db.SaveChanges();

                        //repopulate listbox
                        ListBoxRabbits.ItemsSource = null;
                        ListBoxRabbits.Items.Clear();
                        rabbits = db.Rabbits.ToList();
                        ListBoxRabbits.ItemsSource = rabbits;
                    }
                }
            }
           // if ((TextBoxAge.Text.Length > 0) && (TextBoxName.Text.Length > 0))
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
