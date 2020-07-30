using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VIPServicesRudyViewModel;

namespace VIPServicesRudyUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VIPViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new VIPViewModel();
            vm.AddItems();
            //DataContext = vm;
        }

        private void NewReservationBtn_Click(object sender, RoutedEventArgs e)
        {
            ReservationForm rf = new ReservationForm(vm);
            Close();
            rf.Show();
        }

        private void SearchReservationBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchReservations sr = new SearchReservations(vm);
            Close();
            sr.Show();
        }
    }
}
