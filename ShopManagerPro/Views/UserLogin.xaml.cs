using ShopManagerPro.Models;
using ShopManagerPro.Services;
using System.Linq;
using System.Windows;

namespace ShopManagerPro.Views
{
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string felhasznalonev = loginUserText.Text;
            string jelszo = loginPasswordText.Password;

            var repository =
                new GenericRepository<Felhasznalo>(App.databasePath);

            var felhasznalo =
                repository.GetAll()
                .FirstOrDefault(x =>
                    x.FhNev == felhasznalonev &&
                    x.Jelszo == PasswordHelper.HashPassword(jelszo));

            if (felhasznalo != null)
            {
                MessageBox.Show(
                    $"Sikeres bejelentkezés!\nÜdv {felhasznalo.TeljesNev}");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Hibás felhasználónév vagy jelszó!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}