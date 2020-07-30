using DomainLibrary.Domain.Clients;
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
                TimeSpan.TryParse(StartHourTextBox.Text, out startTime);
                if (startTime == null)
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
                MessageBox.Show("Gelieve een startdatum te selecteren.");
            else
            {
                TimeSpan.TryParse(StartHourTextBox.Text, out endTime);
                if (endTime == null)
                    MessageBox.Show("Gelieve een starttijd in te voeren.");
                else
                {
                    end.Add(endTime);
                    return end;
                }
            }
            return DateTime.MinValue;
        }
    }
}
