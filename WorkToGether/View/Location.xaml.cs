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
using WorkToGether.ViewModels;

namespace WorkToGether.View
{
    /// <summary>
    /// Logique d'interaction pour Location.xaml
    /// </summary>
    public partial class Location : UserControl
    {
        public Location()
        {
            InitializeComponent();
            this.DataContext = new LocationViewModel();

            // Trouver la fenêtre parente
            Window parentWindow = Window.GetWindow(this);

            // Vérifier si la fenêtre parente n'est pas null
            if (parentWindow != null)
            {
                // Définir la propriété WindowState de la fenêtre parente sur Maximized
                parentWindow.WindowState = WindowState.Maximized;
            }
        }

        public void ExportToPdf(object sender, RoutedEventArgs e)
           =>((LocationViewModel)this.DataContext).ExportToPdf();
    }
}
