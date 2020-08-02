using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Limousines;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ReservationForm.xaml
    /// </summary>
    public partial class ReservationForm : Window
    {
        VIPViewModel vm;
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
            AddExistingClient aec = new AddExistingClient(vm,this);
            aec.Show();
            Hide();
        }

        private void AddNewClientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewClient anc = new AddNewClient(vm,this);
            anc.Show();
            Hide();
        }

        private async void AddLimousineBtn_Click(object sender, RoutedEventArgs e)
        {
            await vm.InitializeLimousinesAsync();
            AddLimousine al = new AddLimousine(vm,this);
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
            int streatNumber;
            int postalCode;
            int startTime;
            int endTime;
            if (ClientShowBox.Text == "KlantNaam")
                MessageBox.Show("Gelieve klant in te geven.");
            else if (StartAdresStreat.Text.Length == 0)
                MessageBox.Show("Gelieve straat in te vullen.");
            else if (!int.TryParse(StartAdresNr.Text, out streatNumber))
                MessageBox.Show("Gelieve straatnr in te vullen.");
            else if (!int.TryParse(StartAdresPostalCode.Text, out postalCode))
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
            else if (!int.TryParse(StartHourTextBox.Text, out startTime))
                MessageBox.Show("Gelieve een startuur te selecteren.");
            else if (!int.TryParse(EndHourTextBox.Text, out endTime))
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
                    MessageBox.Show(e.Message,"PriceCalculation", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private async void AddReservationBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show(vm.ShowReservation(),"ReservationDetails",MessageBoxButton.YesNo,MessageBoxImage.Information,MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                await vm.AddReservation();
                Close();
                MessageBox.Show("Reservation Added");
            }
        }

        private void ShowPriceBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowPrice();
        }
    }
}
