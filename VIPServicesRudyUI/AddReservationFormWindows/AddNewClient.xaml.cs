using DomainLibrary.Domain.Clients;
using System.Windows;
using VIPServicesRudyViewModel;

namespace VIPServicesRudyUI
{
    /// <summary>
    /// Interaction logic for AddNewClient.xaml
    /// </summary>
    public partial class AddNewClient : Window
    {
        private readonly VIPViewModel vm;
        readonly ReservationForm parent;
        public AddNewClient(VIPViewModel vm, ReservationForm parent)
        {
            InitializeComponent();
            this.vm = vm;
            this.parent = parent;
            DataContext = vm;
        }

        private void AddClientSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem == null)
                MessageBox.Show("Selecteer een categorie.");
            if (ClientNameInput.Text.Length == 0)
                MessageBox.Show("Gelieve een naam in te geven.");
            if (VATNumberInput.Text.Length == 0)
                MessageBox.Show("Gelieve het BTW-nummer in te vullen.");
            if (!VATNumberInput.Text.StartsWith("BE"))
                MessageBox.Show("Gelieve een geldig BTW-nummer in te vullen.");
            if (StreatInput.Text.Length == 0)
                MessageBox.Show("Gelieve straat in te vullen.");
            if (!int.TryParse(NrInput.Text, out int nr))
                MessageBox.Show("Gelieve een nummer in te vullen.");
            if (!int.TryParse(PostalCodeInput.Text, out int postalCode))
                MessageBox.Show("Gelieve Postcode in te vullen.");
            if (TownInput.Text.Length == 0)
                MessageBox.Show("Gelieve Gemeente in te vullen.");
            else
            {
                parent.MakeClient(ClientNameInput.Text, VATNumberInput.Text, StreatInput.Text + " " + nr + " - " + postalCode + " " + TownInput.Text, (CategorieType)CategoryComboBox.SelectedItem);
                MessageBox.Show(ClientNameInput.Text + " added.");
                parent.Show();
                Close();
            }
        }
    }
}
