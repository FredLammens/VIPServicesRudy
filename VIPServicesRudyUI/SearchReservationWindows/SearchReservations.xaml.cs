using System.Threading.Tasks;
using System.Windows;
using VIPServicesRudyViewModel;

namespace VIPServicesRudyUI
{
    /// <summary>
    /// Interaction logic for SearchReservations.xaml
    /// </summary>
    public partial class SearchReservations : Window
    {
        readonly VIPViewModel vm;
        public SearchReservations(VIPViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = vm;
        }

        private void ShowReservationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (vm.SelectedReservation == null)
                MessageBox.Show("Gelieve een reservatie te selecteren.");
            else
                MessageBox.Show(vm.SelectedReservation.ToString(), "ReservationDetails", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async void ReservationSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchInput = ReservationSearchBox.Text;
            await Task.Run(() => vm.SearchReservation(searchInput));
        }
    }
}
