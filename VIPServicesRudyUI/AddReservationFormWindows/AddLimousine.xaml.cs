using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddLimousine.xaml
    /// </summary>
    public partial class AddLimousine : Window
    {
        VIPViewModel vm;
        ReservationForm parent;
        public AddLimousine(VIPViewModel vm, ReservationForm parent)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = vm;
            this.parent = parent;
        }

        private void SubmitLimousineBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(vm.ShowLimousine() + "Added");
            Close();
            parent.ShowLimousine();
            parent.Show();
        }

        private void AddLimousineSearchBoxBtn_Click(object sender, RoutedEventArgs e)
        {
            vm.SearchLimo(AddLimousineSearchBox.Text);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show("Ben je zeker dat je wilt sluiten zonder op te slaan ?", "LimousineToevoegen", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (message == MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}
