using ShopManagerPro.UserControls;
using System.Windows;
using System.Windows.Input;

namespace ShopManagerPro
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            feladatPanel.Children.Clear();
            feladatPanel.Children.Add(
                new UserControlFelhasznalok());
        }

        private void felhasznalokMenu_MouseLeftButtonUp(
            object sender,
            MouseButtonEventArgs e)
        {
            feladatPanel.Children.Clear();

            feladatPanel.Children.Add(
                new UserControlFelhasznalok());
        }

        private void vevoMenu_MouseLeftButtonUp(
            object sender,
            MouseButtonEventArgs e)
        {
            feladatPanel.Children.Clear();

            feladatPanel.Children.Add(
                new UserControlCustomers());
        }

        private void termekMenu_MouseLeftButtonUp(
            object sender,
            MouseButtonEventArgs e)
        {
            feladatPanel.Children.Clear();

            feladatPanel.Children.Add(
                new UserControlTermekek());
        }

        private void bezarasMenu_MouseLeftButtonUp(
            object sender,
            MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}