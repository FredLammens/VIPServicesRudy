﻿using System;
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
    /// Interaction logic for AddNewClient.xaml
    /// </summary>
    public partial class AddNewClient : Window
    {
        public AddNewClient()
        {
            InitializeComponent();
        }

        private void AddClientSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
