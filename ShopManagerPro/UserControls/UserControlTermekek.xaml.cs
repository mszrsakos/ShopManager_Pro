using ShopManagerPro.Models;
using System.Windows;
using System.Windows.Controls;

namespace ShopManagerPro.UserControls
{
    public partial class UserControlTermekek : UserControl
    {
        private Termek valasztottTermek;

        public UserControlTermekek()
        {
            InitializeComponent();

            ReadDatabase();
        }

        private void ReadDatabase()
        {
            nevTxtBx.Text = "";
            arTxtBx.Text = "";
            mennyisegTxtBx.Text = "";
            markaTxtBx.Text = "";
            sulyTxtBx.Text = "";

            var repo =
                new GenericRepository<Termek>(
                    App.databasePath);

            datagridTermekek.ItemsSource =
                repo.GetAll();

            valasztottTermek = null;
        }

        private void datagridTermekek_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (datagridTermekek.SelectedItem != null)
            {
                valasztottTermek =
                    (Termek)datagridTermekek.SelectedItem;

                nevTxtBx.Text =
                    valasztottTermek.Nev;

                arTxtBx.Text =
                    valasztottTermek.Ar.ToString();

                mennyisegTxtBx.Text =
                    valasztottTermek.Mennyiseg.ToString();

                markaTxtBx.Text =
                    valasztottTermek.Marka;

                sulyTxtBx.Text =
                    valasztottTermek.Suly.ToString();
            }
        }

        private void mentesBtn_Click(
            object sender,
            RoutedEventArgs e)
        {
            Termek uj = new Termek()
            {
                Nev = nevTxtBx.Text,
                Ar = decimal.Parse(arTxtBx.Text),
                Mennyiseg = int.Parse(mennyisegTxtBx.Text),
                Marka = markaTxtBx.Text,
                Suly = double.Parse(sulyTxtBx.Text)
            };

            var repo =
                new GenericRepository<Termek>(
                    App.databasePath);

            repo.insert(uj);

            ReadDatabase();
        }

        private void modBtn_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (valasztottTermek == null)
                return;

            valasztottTermek.Nev =
                nevTxtBx.Text;

            valasztottTermek.Ar =
                decimal.Parse(arTxtBx.Text);

            valasztottTermek.Mennyiseg =
                int.Parse(mennyisegTxtBx.Text);

            valasztottTermek.Marka =
                markaTxtBx.Text;

            valasztottTermek.Suly =
                double.Parse(sulyTxtBx.Text);

            var repo =
                new GenericRepository<Termek>(
                    App.databasePath);

            repo.update(valasztottTermek);

            ReadDatabase();
        }

        private void torlesBtn_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (valasztottTermek == null)
                return;

            var repo =
                new GenericRepository<Termek>(
                    App.databasePath);

            repo.delete(valasztottTermek);

            ReadDatabase();
        }
    }
}