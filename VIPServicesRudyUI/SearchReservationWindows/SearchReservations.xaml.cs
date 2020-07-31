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
            ShowReservation sr = new ShowReservation(vm);
            Close();
            sr.Show();
        }
    }
}
