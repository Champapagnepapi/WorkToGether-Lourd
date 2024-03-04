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
using System.Windows.Shapes;
using WorkToGether.DBLib.Class;
using WorkToGether.ViewModels;

namespace WorkToGether.View
{
    /// <summary>
    /// Logique d'interaction pour AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }
        private void AddUsers(object sender, RoutedEventArgs e)
        {
            if (DataContext is UserViewModel viewModel)
            {
                viewModel.AddUser(
                    NomTextBox.Text,
                    PrenomTextBox.Text,
                    PasswordBox.Password,
                    NumeroTextBox.Text,
                    EmailTextBox.Text,
                    RolesTextBox.Text
                );
            }
        }

    }
}
