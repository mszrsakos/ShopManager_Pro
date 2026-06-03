using ShopManagerPro.Models;
using ShopManagerPro.Services;
using ShopManagerPro;
using System.Windows;
using System.Windows.Controls;

namespace ShopManagerPro.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlFelhasznalok.xaml
    /// </summary>
    public partial class UserControlFelhasznalok : UserControl
    {
        List<Felhasznalo> felhasznalok;
        Felhasznalo valasztottFelhasznalo;

        public UserControlFelhasznalok()
        {
            InitializeComponent();



            ReadDatabase();

            mentesBtn.Visibility = Visibility.Visible;
            modBth.Visibility = Visibility.Hidden;
            torlesBtn.Visibility = Visibility.Hidden;

            szerepkor.ItemsSource = Enum.GetNames(typeof(Szerepkorok));
        }

        private void ReadDatabase()
        {
            szerepkor.SelectedItem =
                Enum.GetName(typeof(Szerepkorok),
                Szerepkorok.Vendég);

            teljesNevTxtBx.Clear();
            felhasznaloNevTxtBx.Clear();
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

        private void datagridFelhasznalok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            modBth.Visibility = Visibility.Visible;
            torlesBtn.Visibility = Visibility.Visible;
            mentesBtn.Visibility = Visibility.Hidden;

            if (datagridFelhasznalok.SelectedItem != null)
            {
                valasztottFelhasznalo = (Felhasznalo)datagridFelhasznalok.SelectedItem;
                felhasznaloNevTxtBx.Text = valasztottFelhasznalo.FhNev;
                szerepkor.Text = valasztottFelhasznalo.SzerepkorNev;
            }
        }

        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {

            var FelhasznaloRepository = new GenericRepository<Felhasznalo>(App.databasePath);
            FelhasznaloRepository.delete(valasztottFelhasznalo);
            ReadDatabase();

        }

        private void modBth_Click(object sender, RoutedEventArgs e)
        {
            valasztottFelhasznalo.FhNev = felhasznaloNevTxtBx.Text;
            valasztottFelhasznalo.TeljesNev = teljesNevTxtBx.Text;
            string kivalasztottSzerepkorNev = (string)szerepkor.SelectedItem;
            Szerepkorok kivalasztottSzerepkor = (Szerepkorok)Enum.Parse(typeof(Szerepkorok), kivalasztottSzerepkorNev);
            int kivalasztottSzerepkorId = (int)kivalasztottSzerepkor;
            valasztottFelhasznalo.Szerepkor = kivalasztottSzerepkorId;

            //TODO: jelszó - SHA!!!!! - jelszót csak akkor módosítunk ha megadja az inputban. 
            if (jelszoBx.Password != "")
            {
                valasztottFelhasznalo.Jelszo = PasswordHelper.HashPassword(jelszoBx.Password);
            }

            // Repo update:
            var FelhasznaloRepository = new GenericRepository<Felhasznalo>(App.databasePath);
            FelhasznaloRepository.update(valasztottFelhasznalo);

            //Datagrid update:
            ReadDatabase();


        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {
            //Szerepkör névből szerepkörID
            string kivalasztottSzerepkorNev = (string)szerepkor.SelectedItem;
            Szerepkorok kivalasztottSzerepkor = (Szerepkorok)Enum.Parse(typeof(Szerepkorok), kivalasztottSzerepkorNev);
            int kivalasztottSzerepkorId = (int)kivalasztottSzerepkor;

            // Uj felhasználó objektum létrehozás
            Felhasznalo ujFelhasznalo = new Felhasznalo(felhasznaloNevTxtBx.Text,
                teljesNevTxtBx.Text, PasswordHelper.HashPassword(jelszoBx.Password), kivalasztottSzerepkorId);

            // Uj user repo, insert to db
            var FelhasznaloRepository = new GenericRepository<Felhasznalo>(App.databasePath);
            FelhasznaloRepository.insert(ujFelhasznalo);

            //Datagrid update:
            ReadDatabase();

        }
    }
}
