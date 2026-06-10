using ShopManagerPro.Models;
using ShopManagerPro.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ShopManagerPro.UserControls
{
    public partial class UserControlFelhasznalok : UserControl
    {
        private Felhasznalo valasztottFelhasznalo;

        public UserControlFelhasznalok()
        {
            InitializeComponent();

            szerepkor.ItemsSource =
                Enum.GetNames(typeof(Szerepkorok));

            ReadDatabase();
        }

        private void ReadDatabase()
        {
            szerepkor.SelectedItem =
                Enum.GetName(typeof(Szerepkorok),
                Szerepkorok.Vendég);

            felhasznaloNevTxtBx.Clear();
            teljesNevTxtBx.Clear();
            jelszoBx.Clear();

            var repository =
                new GenericRepository<Felhasznalo>(App.databasePath);

            datagridFelhasznalok.ItemsSource =
                repository.GetAll();

            datagridFelhasznalok.SelectedItem = null;
            valasztottFelhasznalo = null;

            mentesBtn.Visibility = Visibility.Visible;
            modBth.Visibility = Visibility.Hidden;
            torlesBtn.Visibility = Visibility.Hidden;
        }

        private void datagridFelhasznalok_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (datagridFelhasznalok.SelectedItem == null)
                return;

            valasztottFelhasznalo =
                (Felhasznalo)datagridFelhasznalok.SelectedItem;

            felhasznaloNevTxtBx.Text =
                valasztottFelhasznalo.FhNev;

            teljesNevTxtBx.Text =
                valasztottFelhasznalo.TeljesNev;

            szerepkor.Text =
                valasztottFelhasznalo.SzerepkorNev;

            mentesBtn.Visibility = Visibility.Hidden;
            modBth.Visibility = Visibility.Visible;
            torlesBtn.Visibility = Visibility.Visible;
        }

        private void mentesBtn_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(felhasznaloNevTxtBx.Text))
                return;

            string szerepkorNev =
                (string)szerepkor.SelectedItem;

            Szerepkorok szerepkorEnum =
                (Szerepkorok)Enum.Parse(
                    typeof(Szerepkorok),
                    szerepkorNev);

            Felhasznalo ujFelhasznalo =
                new Felhasznalo(
                    felhasznaloNevTxtBx.Text,
                    teljesNevTxtBx.Text,
                    PasswordHelper.HashPassword(jelszoBx.Password),
                    (int)szerepkorEnum);

            var repository =
                new GenericRepository<Felhasznalo>(App.databasePath);

            repository.insert(ujFelhasznalo);

            ReadDatabase();
        }

        private void modBth_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (valasztottFelhasznalo == null)
                return;

            valasztottFelhasznalo.FhNev =
                felhasznaloNevTxtBx.Text;

            valasztottFelhasznalo.TeljesNev =
                teljesNevTxtBx.Text;

            string szerepkorNev =
                (string)szerepkor.SelectedItem;

            Szerepkorok szerepkorEnum =
                (Szerepkorok)Enum.Parse(
                    typeof(Szerepkorok),
                    szerepkorNev);

            valasztottFelhasznalo.Szerepkor =
                (int)szerepkorEnum;

            if (!string.IsNullOrWhiteSpace(jelszoBx.Password))
            {
                valasztottFelhasznalo.Jelszo =
                    PasswordHelper.HashPassword(
                        jelszoBx.Password);
            }

            var repository =
                new GenericRepository<Felhasznalo>(App.databasePath);

            repository.update(valasztottFelhasznalo);

            ReadDatabase();
        }

        private void torlesBtn_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (valasztottFelhasznalo == null)
                return;

            var repository =
                new GenericRepository<Felhasznalo>(App.databasePath);

            repository.delete(valasztottFelhasznalo);

            ReadDatabase();
        }
    }
}