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
    /// Logique d'interaction pour User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        private readonly UserViewModel _viewModel;
        private readonly AddUser _addUserWindow;

        public User()
        {
            InitializeComponent();
            _viewModel = new UserViewModel();
            DataContext = _viewModel;

        }


        private void UpdateUser(object sender, RoutedEventArgs e)
        => ((UserViewModel)this.DataContext).UpdateUser();

        private void DeleteUser(object sender, RoutedEventArgs e)
        => ((UserViewModel)this.DataContext).DeleteUser();

        private void AjouterUserButton_Click(object sender, RoutedEventArgs e)
           => ((UserViewModel)this.DataContext).AjouterUserButton_Click();
 
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
             => ((UserViewModel)this.DataContext).RetourButton_Click();

   

    }
}
