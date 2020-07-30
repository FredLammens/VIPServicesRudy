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
    /// Interaction logic for AddLimousine.xaml
    /// </summary>
    public partial class AddLimousine : Window
    {
        VIPViewModel vm;
        public AddLimousine(VIPViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = vm;
            //LimousineDataGrid1.Items.Refresh();
        }

        private void SubmitLimousineBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
