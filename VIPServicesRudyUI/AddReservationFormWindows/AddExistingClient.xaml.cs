using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using VIPServicesRudyViewModel;

namespace VIPServicesRudyUI
{
    /// <summary>
    /// Interaction logic for AddExistingClient.xaml
    /// </summary>
    public partial class AddExistingClient : Window
    {
        private VIPViewModel vm;
        private ReservationForm parent;
        public AddExistingClient(VIPViewModel vm, ReservationForm parent)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = vm;
            this.parent = parent;
        }

        private void AddClientForm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(vm.ShowClient() + " added.");
            Close();
            parent.ShowClient();
            parent.Show();
        }

        private async void AddExistingClientSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchInput = AddExistingClientSearchBox.Text;
            await Task.Run(() => vm.SearchClient(searchInput));
        }
    }
}
