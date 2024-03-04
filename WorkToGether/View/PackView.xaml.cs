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
    /// Logique d'interaction pour PackView.xaml
    /// </summary>
    public partial class PackView : UserControl
    {
        public PackView()
        {
            InitializeComponent();
            this.DataContext = new PackViewModel();
        }

        private void updatePack(object sender, RoutedEventArgs e)
        => ((PackViewModel)this.DataContext).updatePack();

        private void DeletePack(object sender, RoutedEventArgs e)
        => ((PackViewModel)this.DataContext).DeletePack();

        private void AjouterPackButton_Click(object sender, RoutedEventArgs e)
            => ((PackViewModel)this.DataContext).AjouterPackButton_Click();
    }
}
