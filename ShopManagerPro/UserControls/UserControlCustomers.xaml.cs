using ShopManagerPro.Models;
using System.Windows;
using System.Windows.Controls;

namespace ShopManagerPro.UserControls
{
    public partial class UserControlCustomers : UserControl
    {
        private Customer valasztottCustomer;

        public UserControlCustomers()
        {
            InitializeComponent();

            ReadDatabase();
        }

        private void ReadDatabase()
        {
            phoneTxtBx.Text = "";
            addressTxtBx.Text = "";
            cityTxtBx.Text = "";
            countryTxtBx.Text = "";
            loyaltyTxtBx.Text = "";

            var repo =
                new GenericRepository<Customer>(
                    App.databasePath);

            datagridCustomers.ItemsSource =
                repo.GetAll();

            valasztottCustomer = null;
        }

        private void datagridCustomers_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (datagridCustomers.SelectedItem != null)
            {
                valasztottCustomer =
                    (Customer)datagridCustomers.SelectedItem;

                phoneTxtBx.Text =
                    valasztottCustomer.PhoneNumber;

                addressTxtBx.Text =
                    valasztottCustomer.Address;

                cityTxtBx.Text =
                    valasztottCustomer.City;

                countryTxtBx.Text =
                    valasztottCustomer.Country;

                loyaltyTxtBx.Text =
                    valasztottCustomer.LoyaltyPoints.ToString();
            }
        }

        private void mentesBtn_Click(
            object sender,
            RoutedEventArgs e)
        {
            Customer uj = new Customer()
            {
                PhoneNumber = phoneTxtBx.Text,
                Address = addressTxtBx.Text,
                City = cityTxtBx.Text,
                Country = countryTxtBx.Text,
                LoyaltyPoints = int.Parse(loyaltyTxtBx.Text)
            };

            var repo =
                new GenericRepository<Customer>(
                    App.databasePath);

            repo.insert(uj);

            ReadDatabase();
        }

        private void modBtn_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (valasztottCustomer == null)
                return;

            valasztottCustomer.PhoneNumber =
                phoneTxtBx.Text;

            valasztottCustomer.Address =
                addressTxtBx.Text;

            valasztottCustomer.City =
                cityTxtBx.Text;

            valasztottCustomer.Country =
                countryTxtBx.Text;

            valasztottCustomer.LoyaltyPoints =
                int.Parse(loyaltyTxtBx.Text);

            var repo =
                new GenericRepository<Customer>(
                    App.databasePath);

            repo.update(valasztottCustomer);

            ReadDatabase();
        }

        private void torlesBtn_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (valasztottCustomer == null)
                return;

            var repo =
                new GenericRepository<Customer>(
                    App.databasePath);

            repo.delete(valasztottCustomer);

            ReadDatabase();
        }
    }
}