using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using DataLayer;
using DomainLibrary.Domain;
using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Reservering;

namespace VIPServicesRudyViewModel
{
    public class VIPViewModel : INotifyPropertyChanged
    {
        #region propertyHandler
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region collections
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                RaisePropertyChanged("Clients");
            }
        }
        private ObservableCollection<Limousine> _limousines;
        public ObservableCollection<Limousine> Limousines
        {
            get { return _limousines; }
            set
            {
                _limousines = value; RaisePropertyChanged("Limousines");
            }
        }
        private ObservableCollection<Reservation> _reservations;
        public ObservableCollection<Reservation> Reservations
        {
            get { return _reservations; }
            set
            {
                _reservations = value;
                RaisePropertyChanged("Reservations");
            }
        }
        #endregion
        public Client SelectedClient { get; set; }
        public Limousine SelectedLimousine { get; set; }
        public System.Array Categories { get; set; } = Enum.GetValues(typeof(CategorieType));
        public System.Array Locations { get; set; } = Enum.GetValues(typeof(Location));
        public void AddItems()
        {
            VIPServicesRudyManager manager = new VIPServicesRudyManager(new UnitOfWork(new VIPServicesRudyContext()));
            Clients = new ObservableCollection<Client>(manager.GetClients());
            Limousines = new ObservableCollection<Limousine>(manager.GetAllLimousine());
            Reservations = new ObservableCollection<Reservation>(manager.GetReservations());
        }
        public string ShowClient()
        {
            if (SelectedClient == null)
                return "Klantnaam";
            else
                return SelectedClient.Name;
        }
        public string ShowLimousine()
        {
            if (SelectedLimousine == null)
                return "LimousineNaam";
            else
                return SelectedLimousine.Name;
        }
        public string MakeClient(string name, string VATNumber, string adres, CategorieType type)
        {
                VIPServicesRudyManager manager = new VIPServicesRudyManager(new UnitOfWork(new VIPServicesRudyContext()));
                Client client = new Client(name, VATNumber, adres, manager.GetCategory(type));
                SelectedClient = client;
                return name;
        }

    }
}
