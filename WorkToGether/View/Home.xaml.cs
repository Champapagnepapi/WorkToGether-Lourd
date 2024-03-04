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
using WorkToGether.DBLib.Class;
using WorkToGether.ViewModels;

namespace WorkToGether.View
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }



            private void LesBaiesButton_Click(object sender, RoutedEventArgs e)
            {
                
                BaiesViews baiesViews = new BaiesViews();
                Window baiesWindow = new Window
                {
                    Content = baiesViews,
                    Title = "Baies Views",
                    Width = 800,
                    Height = 600,
                };

                baiesWindow.Show();
            }

        private void LesLocation(object sender, RoutedEventArgs e)
        {
            Location location = new Location();

            Window window = new Window
            {
                Content = location,
                Title = "Locations",
                Width = 800,
                Height = 600,
            };

            window.Show();
        }



        private void LesPacks(object sender, RoutedEventArgs e)
        {
            PackView pack = new PackView();
            Window window = new Window
            {
                Content= pack,
                Title = "Les Packs",
                Width = 800,
                Height = 600,

            };
            window.Show();

        }

        private void LesUsers(object sender, RoutedEventArgs e)
        {
            User user = new User();
            Window window = new Window
            {
                Content = user,
                Title = "Les User",
                Width = 800,
                Height = 600,

            };
            window.Show();


        }
    }
    }



