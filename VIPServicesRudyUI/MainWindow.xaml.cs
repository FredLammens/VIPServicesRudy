using System.Windows;
using System.Windows.Input;
using VIPServicesRudyViewModel;

namespace VIPServicesRudyUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly VIPViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new VIPViewModel();
        }

        private void NewReservationBtn_Click(object sender, RoutedEventArgs e)
        {
            ReservationForm rf = new ReservationForm(vm);
            Hide();
            rf.Show();
        }

        private async void SearchReservationBtn_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            await vm.InitializeReservationsAsync();
            Mouse.OverrideCursor = null;
            SearchReservations sr = new SearchReservations(vm);
            Close();
            sr.Show();
        }
    }
}
