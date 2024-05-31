using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
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

    public partial class AddUser : Window
    {
     

        public event EventHandler UserAddedSuccessfully;
        public AddUser()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel();
        }

        private void AddUsers(object sender, RoutedEventArgs e)
        {
            string hashedPassword = HashPassword(PasswordBox.Password);

            // Appeler la méthode AddUsers du UserViewModel pour ajouter l'utilisateur
            ((UserViewModel)this.DataContext).AddUsers(
                    NomTextBox.Text,
                    PrenomTextBox.Text,
                    hashedPassword,
                    NumeroTextBox.Text,
                    EmailTextBox.Text,
                    RolesTextBox.Text
            );

         


            // Fermer la fenêtre d'ajout d'utilisateur
            Close();
        }




        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
