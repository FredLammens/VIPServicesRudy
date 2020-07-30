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

namespace VIPServicesRudyUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewReservationBtn_Click(object sender, RoutedEventArgs e)
        {
            ReservationForm rf = new ReservationForm();
            Close();
            rf.Show();
        }

        private void SearchReservationBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchReservations sr = new SearchReservations();
            Close();
            sr.Show();
        }
    }
}
