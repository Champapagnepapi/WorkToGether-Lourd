using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
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
using WorkToGether.View;
using WorkToGether.ViewModels;
using BCrypt.Net;


namespace WorkToGether
{
    /// <summary>
    ///
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string useremail = userEmailTextBox.Text;
            string password = passwordBox.Password;


            bool isValidUser = AuthenticateUser(useremail, password);
            if (!isValidUser)
            {
                errorMessageTextBlock.Text = "Email ou mot de passe incorrect.";
            }
        }

        private bool AuthenticateUser(string useremail, string password)
        {
            using (WorkToGetherContext context = new WorkToGetherContext())
            {
                DBLib.Class.User? user = context.Users.FirstOrDefault(u => u.Email == useremail);

                if (user is not null)
                {
                    if (VerifyPassword(password, user.Password))
                    {

                        if (user.Roles.Contains("ROLE_ADMIN") || user.Roles.Contains("ROLE_Comptabilite"))
                        {
                            ((App)Application.Current).CurrentUser = user;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Accès non autorisé. Vous n'avez pas les autorisations nécessaires pour accéder à cette application.");
                            return false;
                        }
                    }
                }
                return false;
            }
        }





        private bool VerifyPassword(string password, string hashedPassword)
        {

            if (hashedPassword.StartsWith("$2y$"))
            {

                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
            else if (hashedPassword.StartsWith("$13$"))
            {

                string salt = hashedPassword.Substring(4, 16);


                using (SHA512 sha512 = SHA512.Create())
                {

                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);


                    byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(salt + password);

                    byte[] hashedInputBytes = sha512.ComputeHash(saltedPasswordBytes);


                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < hashedInputBytes.Length; i++)
                    {
                        builder.Append(hashedInputBytes[i].ToString("x2"));
                    }
                    string hashedInputString = builder.ToString();


                    return hashedInputString.Equals(hashedPassword.Substring(20));
                }
            }

            return false;
        }


    }


}

