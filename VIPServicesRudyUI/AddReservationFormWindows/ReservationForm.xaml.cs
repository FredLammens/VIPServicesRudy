using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Limousines;
using System;
using System.Collections.Generic;
using System.Text;
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
            StartLocationComboBox.ItemsSource = vm.Locations;
            ArrivalLocationComboBox.ItemsSource = vm.Locations;
            ArrangementComboBox.ItemsSource = vm.Arrangements;
            ArrangementComboBox.SelectedIndex = 1;
        }

        private void AddExistingCLientBtn_Click(object sender, RoutedEventArgs e)
        {
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

        private void AddLimousineBtn_Click(object sender, RoutedEventArgs e)
        {
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
            ClientShowBox.Text = vm.MakeClient(name,VATNumber,adres,categorie);
        }
        private DateTime GetReservationStart()
        {
            DateTime start = ReservationStartDate.SelectedDate.GetValueOrDefault(DateTime.MinValue);
            TimeSpan startTime;
            if (start == DateTime.MinValue)
                MessageBox.Show("Gelieve een startdatum te selecteren.");
            else 
            {
                if(!TimeSpan.TryParse(StartHourTextBox.Text, out startTime))
                    MessageBox.Show("Gelieve een starttijd in te voeren.");
                else 
                {
                    start.Add(startTime);
                    return start;
                }
            }
            return DateTime.MinValue;
        }
        private DateTime GetReservationEnd() 
        {
            DateTime end = ReservationEndDate.SelectedDate.GetValueOrDefault(DateTime.MinValue);
            TimeSpan endTime;
            if (end == DateTime.MinValue)
                MessageBox.Show("Gelieve een eindDatum te selecteren.");
            else
            {
                if(!TimeSpan.TryParse(StartHourTextBox.Text, out endTime))
                    MessageBox.Show("Gelieve een eindtijd in te voeren.");
                else
                {
                    end.Add(endTime);
                    return end;
                }
            }
            return DateTime.MinValue;
        }
        private void ShowPrice()
        {
            //check if all the other boxes are inserted 
            //check client
            int streatNumber;
            int postalCode;
            if (ClientShowBox.Text == "KlantNaam")
                MessageBox.Show("Gelieve klant in te geven.");
            else if (StartAdresStreat.Text.Length == 0)
                MessageBox.Show("Gelieve straat in te vullen.");
            else if (!int.TryParse(StartAdresNr.Text, out streatNumber))
                MessageBox.Show("Gelieve straatnr in te vullen.");
            else if (!int.TryParse(StartAdresPostalCode.Text,out postalCode))
                MessageBox.Show("Gelieve postcode in te vullen.");
            else if (StartAdresTown.Text.Length == 0)
                MessageBox.Show("Gelieve gemeente in te vullen.");
            else if (StartLocationComboBox.SelectedItem == null)
                MessageBox.Show("Gelieve startLocatie te selecteren.");
            else if (ArrivalLocationComboBox.SelectedItem == null)
                MessageBox.Show("Gelieve aankomstLocatie te selecteren.");
            else if (LimousineShowBox.Text == "LimousineNaam")
                MessageBox.Show("Gelieve limousine te selecteren.");
            else if (GetReservationStart() != DateTime.MinValue && GetReservationEnd() != DateTime.MinValue)
            {
                //kijken of nr en postcode nummers zijn 
                string adres = StartAdresStreat.Text
                             + streatNumber
                             + postalCode
                             + StartAdresTown.Text;
                PriceField.Text = vm.GetPrice(adres, GetReservationStart(), GetReservationEnd());
            }
        }

        private void AddReservationBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ArrangementComboBox_DropDownClosed(object sender, EventArgs e)
        {
            ShowPrice();
        }
    }
}
