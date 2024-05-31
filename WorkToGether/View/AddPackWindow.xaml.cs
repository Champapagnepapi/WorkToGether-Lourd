using System.Windows;
using WorkToGether.ViewModels;

namespace WorkToGether.View
{
    public partial class AddPackWindow : Window
    {
        public AddPackWindow()
        {
            InitializeComponent();
            this.DataContext = new PackViewModel();
        }

        private void AddPack(object sender, RoutedEventArgs e)
        {
            ((PackViewModel)this.DataContext).AddPack(NomTextBox.Text, PrixTextBox.Text, NombreEmplacementTextBox.Text, ReductionTextBox.Text);
            
            Close();

        }
    }
}
