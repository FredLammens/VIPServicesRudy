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
    /// Interaction logic for AddNewClient.xaml
    /// </summary>
    public partial class AddNewClient : Window
    {
        VIPViewModel vm;
        ReservationForm parent;
        public AddNewClient(VIPViewModel vm, ReservationForm parent)
        {
            InitializeComponent();
            this.vm = vm;
            this.parent = parent;
            CategoryComboBox.ItemsSource = vm.Categories;
        }

        private void AddClientSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem == null)
                MessageBox.Show("Selecteer een categorie a.u.b");
            else
            {
                parent.MakeClient(ClientNameInput.Text, VATNumberInput.Text, StreatInput.Text + NrInput.Text + PostalCodeInput.Text + TownInput.Text, (CategorieType)CategoryComboBox.SelectedItem);
                MessageBox.Show(ClientNameInput.Text + " added.");
                parent.Show();
                Close();
            }
        }
    }
}
