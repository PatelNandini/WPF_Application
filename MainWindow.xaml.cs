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

namespace MTNandiniPatel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        enum categories
        {
            Hatchback, 
            Sedan, 
            SUV, 
            Cruiser,
            Sports, 
            Dirt
        }

        enum types
        {
            Standard, Exotic, Bike, Trike
        }
        private List<Car> vehicles;
        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBox();

            vehicles = new List<Car>()
            {
                new Car(1, "Honda Civic", "69.9", "Sedan", "Standard", false),
                new Car(2, "Toyota Corolla", "69.9", "Sedan", "Standard", true),
                new Car(3, "Ford Explorer", "99.9", "SUV", "Standard", false),
                new Car(4, "Nissan Versa", "49.9", "Hatchback", "Standard", true),
                new Car(5, "Hyundai Tucson", "89.9", "SUV", "Standard", false),
                new Car(6, "Lamborghini Aventador", "189.9", "Sports", "Exotic", false),
                new Car(7, "Ferrari 488 GTB", "179.9", "Sports", "Exotic", true),
                new Car(8,"MacLaren P1", "199.9", "Sports", "Exotic", true),
                new Car(9, "Suzuki Boulevard M109R", "49.9", "Crusier", "Bike", true),
                new Car(10,"Harley-Davidson Street Glide", "79.9", "Crusier", "Bike", false),
                new Car(11,"Honda CRF125", "39.9", "Dirt", "Bike", false),
                new Car(12,"Ducati Monster", "69.9", "Sports", "Bike", false),
                new Car(13,"Can-Am Spyder", "59.9", "Cruiser", "Trike", false),
                new Car(14,"Polaris Slingshot", "69.9", "Cruiser", "Trike", true)
            };
           
        }

        private void InitializeComboBox()
        {
            //string[] enumcategory = Enum.GetNames(typeof(categories));

            //txtcategory.SelectedIndex=(int) categories.Hatchback;

            //string[] enumtype = Enum.GetNames(typeof(types));

            //txtcategory.SelectedIndex = (int)types.Bike;
            //txtcategory.Items.Add(Enum.GetNames(typeof(categories)));
            //txtType.Items.Add(Enum.GetNames(typeof(types)));
        }
        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshListBox();
            txtcategory.ItemsSource=Enum.GetValues(typeof(categories));
            txtType.ItemsSource = Enum.GetValues(typeof(types));
        }

        private void RefreshListBox()
        {

            var names = from vehicle in vehicles select vehicle.name;

            listBox.ItemsSource = names;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (listBox.SelectedItem != null)
            {
                Car v = vehicles[listBox.SelectedIndex];
                if(v.type == "Bike" || v.type == "Trike")
                {
                    rdmotorCycle.IsChecked = true;
                }
                else
                {
                    rdCar.IsChecked = true;
                }
                txtid.Text = v.id.ToString();
                txtname.Text = v.name;
                txtRentalPrice.Text = v.rentalPrice.ToString();
                txtcategory.Text = v.category;
                txtType.Text = v.type;
                reserved.IsChecked=v.isReserved;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

            Car v = new Car(vehicles.Count, txtname.Text, txtRentalPrice.Text, txtcategory.Text, txtType.Text, reserved.IsChecked.GetValueOrDefault());
            vehicles.Add(v);

            txtid.Text = txtname.Text = txtRentalPrice.Text = txtcategory.Text = txtType.Text = "";
            reserved.IsChecked = false;
            RefreshListBox();
            MessageBox.Show("The data has been added.");
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            int index = listBox.SelectedIndex;
            Car v = vehicles[index];

            v.name = txtname.Text;
            v.rentalPrice = txtRentalPrice.Text;
            v.category = txtcategory.Text;
            v.type = txtType.Text;
            v.isReserved = reserved.IsChecked.GetValueOrDefault();

            txtid.Text = txtname.Text = txtRentalPrice.Text = txtcategory.Text = txtType.Text = "";
            reserved.IsChecked = false;
            RefreshListBox();
            MessageBox.Show("The data has been updated.");

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int index = listBox.SelectedIndex;
            vehicles.RemoveAt(index);
            //Car v = vehicles[listBox.SelectedIndex];
            //vehicles.Remove((Car)v);

            txtid.Text = txtname.Text = txtRentalPrice.Text = txtcategory.Text = txtType.Text = "";
            reserved.IsChecked = false;

            for(int i=0; i < vehicles.Count; i++)
                vehicles[i].id = i;
            RefreshListBox();
            MessageBox.Show("The data has been deleted.");
        }

        private void clearList_Click(object sender, RoutedEventArgs e)
        {
            // listBox.Items.Clear();
            vehicles.Clear();
            
            RefreshListBox();
            MessageBox.Show("The list box is cleared.");
        }

        private void resetList_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != 14)
            {

                var names = from vehicle in vehicles select vehicle.name;

                listBox.ItemsSource = names;

                MessageBox.Show("Data reset.");
            }
            else
            {
                MessageBox.Show("fail");
            }
          
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            txtid.Text = txtname.Text = txtRentalPrice.Text = txtcategory.Text = txtType.Text = "";
            reserved.IsChecked = false;
        }
    }
}
