using System.Threading.Tasks;
using System.Windows;
using VIPServicesRudyViewModel;

namespace VIPServicesRudyUI
{
    /// <summary>
    /// Interaction logic for AddExistingClient.xaml
    /// </summary>
    public partial class AddExistingClient : Window
    {
        private readonly VIPViewModel vm;
        private readonly ReservationForm parent;
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
