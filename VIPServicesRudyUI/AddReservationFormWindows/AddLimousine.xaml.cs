using System.Threading.Tasks;
using System.Windows;
using VIPServicesRudyViewModel;

namespace VIPServicesRudyUI
{
    /// <summary>
    /// Interaction logic for AddLimousine.xaml
    /// </summary>
    public partial class AddLimousine : Window
    {
        readonly VIPViewModel vm;
        readonly ReservationForm parent;
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

        private async void AddLimousineSearchBoxBtn_Click(object sender, RoutedEventArgs e)
        {
            string searchInput = AddLimousineSearchBox.Text;
            await Task.Run(() => vm.SearchLimo(searchInput));
        }
    }
}
