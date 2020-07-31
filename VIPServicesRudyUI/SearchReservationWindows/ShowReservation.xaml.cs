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
    /// Interaction logic for ShowReservation.xaml
    /// </summary>
    public partial class ShowReservation : Window
    {
        VIPViewModel vm;
        public ShowReservation(VIPViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;

        }
    }
}
