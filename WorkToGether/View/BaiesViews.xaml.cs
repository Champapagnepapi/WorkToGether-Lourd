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
    /// Logique d'interaction pour BaiesViews.xaml
    /// </summary>
    public partial class BaiesViews : UserControl
    {
        public BaiesViews()
        {
            InitializeComponent();
            this.DataContext = new BaiesViewsViewModel();
            
            
        }

        private void DeleteBaie(object sender, RoutedEventArgs e)
        =>((BaiesViewsViewModel)this.DataContext).DeleteBaie();

        private void updateBaie(object sender, RoutedEventArgs e)
        =>((BaiesViewsViewModel)this.DataContext).updateBaie();
        private void addBaie(object sender, RoutedEventArgs e)
        =>((BaiesViewsViewModel)this.DataContext).addBaie();

    }
}
