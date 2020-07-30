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

namespace VIPServicesRudyUI
{
    /// <summary>
    /// Interaction logic for ReservationForm.xaml
    /// </summary>
    public partial class ReservationForm : Window
    {
        public ReservationForm()
        {
            InitializeComponent();
        }

        private void AddExistingCLientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddExistingClient aec = new AddExistingClient();
            aec.Show();
        }

        private void AddNewClientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddNewClient anc = new AddNewClient();
            anc.Show();
        }

        private void AddLimousineBtn_Click(object sender, RoutedEventArgs e)
        {
            AddLimousine al = new AddLimousine();
            al.Show();
        }
    }
}
