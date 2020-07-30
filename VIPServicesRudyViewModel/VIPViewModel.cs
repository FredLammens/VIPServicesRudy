using System.Collections.ObjectModel;
using System.ComponentModel;
using DataLayer;
using DomainLibrary.Domain;
using DomainLibrary.Domain.Clients;
namespace VIPServicesRudyViewModel
{
    public class VIPViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                _clients = value;
                RaisePropertyChanged("Clients");
            }
        }


        public void addClientItems() 
        {
            VIPServicesRudyManager manager = new VIPServicesRudyManager(new UnitOfWork(new VIPServicesRudyContext()));
            Clients = new ObservableCollection<Client>(manager.GetClients());
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
