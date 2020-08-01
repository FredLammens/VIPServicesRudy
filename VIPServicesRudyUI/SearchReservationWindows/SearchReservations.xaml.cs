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
    /// Interaction logic for SearchReservations.xaml
    /// </summary>
    public partial class SearchReservations : Window
    {
        VIPViewModel vm;
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

        private void ReservationSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            vm.SearchReservation(ReservationSearchBox.Text);
        }
    }
}
