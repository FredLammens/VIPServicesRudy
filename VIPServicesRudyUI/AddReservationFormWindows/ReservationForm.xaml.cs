using DomainLibrary.Domain.Clients;
using System;
using System.Windows;
using VIPServicesRudyViewModel;

namespace VIPServicesRudyUI
{
    /// <summary>
    /// Interaction logic for ReservationForm.xaml
    /// </summary>
    public partial class ReservationForm : Window
    {
        readonly VIPViewModel vm;
        public ReservationForm(VIPViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = vm;
            ReservationStartDate.DisplayDateStart = DateTime.Today;
            ReservationEndDate.DisplayDateStart = DateTime.Today;
        }

        private async void AddExistingCLientBtn_Click(object sender, RoutedEventArgs e)
        {
            await vm.InitializeClientsAsync();
            AddExistingClient aec = new AddExistingClient(vm, this);
            aec.Show();
            Hide();
        }

        private void AddNewClientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewClient anc = new AddNewClient(vm, this);
            anc.Show();
            Hide();
        }

        private async void AddLimousineBtn_Click(object sender, RoutedEventArgs e)
        {
            await vm.InitializeLimousinesAsync();
            AddLimousine al = new AddLimousine(vm, this);
            al.Show();
            Hide();
        }
        public void ShowClient()
        {
            ClientShowBox.Text = vm.ShowClient();
        }
        public void ShowLimousine()
        {
            LimousineShowBox.Text = vm.ShowLimousine();
        }
        public void MakeClient(string name, string VATNumber, string adres, CategorieType categorie)
        {
            ClientShowBox.Text = vm.MakeClient(name, VATNumber, adres, categorie);
        }
        private void ShowPrice()
        {
            //check if all the other boxes are inserted 
            //check client
            if (ClientShowBox.Text == "KlantNaam")
                MessageBox.Show("Gelieve klant in te geven.");
            else if (StartAdresStreat.Text.Length == 0)
                MessageBox.Show("Gelieve straat in te vullen.");
            else if (!int.TryParse(StartAdresNr.Text, out int streatNumber))
                MessageBox.Show("Gelieve straatnr in te vullen.");
            else if (!int.TryParse(StartAdresPostalCode.Text, out int postalCode))
                MessageBox.Show("Gelieve postcode in te vullen.");
            else if (StartAdresTown.Text.Length == 0)
                MessageBox.Show("Gelieve gemeente in te vullen.");
            else if (StartLocationComboBox.SelectedItem == null)
                MessageBox.Show("Gelieve startLocatie te selecteren.");
            else if (ArrivalLocationComboBox.SelectedItem == null)
                MessageBox.Show("Gelieve aankomstLocatie te selecteren.");
            else if (LimousineShowBox.Text == "LimousineNaam")
                MessageBox.Show("Gelieve limousine te selecteren.");
            else if (ReservationStartDate.SelectedDate.GetValueOrDefault(DateTime.MinValue) == DateTime.MinValue)
                MessageBox.Show("Gelieve een startDatum te selecteren.");
            else if (ReservationEndDate.SelectedDate.GetValueOrDefault(DateTime.MinValue) == DateTime.MinValue)
                MessageBox.Show("Gelieve een eindDatum te selecteren.");
            else if (!int.TryParse(StartHourTextBox.Text, out int startTime))
                MessageBox.Show("Gelieve een startuur te selecteren.");
            else if (!int.TryParse(EndHourTextBox.Text, out int endTime))
                MessageBox.Show("Gelieve een einduur te selecteren.");
            else if (ArrangementComboBox.SelectedItem == null)
                MessageBox.Show("Gelieve een arrangement te selecteren.");
            else
            {
                string adres = StartAdresStreat.Text
                             + " " + streatNumber + " -"
                             + " " + postalCode
                             + " " + StartAdresTown.Text;
                DateTime start = ReservationStartDate.SelectedDate.GetValueOrDefault(DateTime.MinValue);
                DateTime end = ReservationEndDate.SelectedDate.GetValueOrDefault(DateTime.MinValue);
                vm.SelectedArrangement = ArrangementComboBox.SelectedValue.ToString();
                try
                {
                    PriceField.Text = vm.GetPrice(adres, start.AddHours(startTime), end.AddHours(endTime));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "PriceCalculation", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private async void AddReservationBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show(vm.ShowReservation(), "ReservationDetails", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                await vm.AddReservation();
                Close();
                MessageBox.Show("Reservation Added");
                MainWindow mw = new MainWindow();
                mw.Show();
            }
        }

        private void ShowPriceBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowPrice();
        }
    }
}
