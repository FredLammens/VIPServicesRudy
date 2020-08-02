using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DomainLibrary.Domain;
using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Limousines.FixedArrangements;
using DomainLibrary.Domain.Limousines.HourlyArrangements;
using DomainLibrary.Domain.Reservering;
using Microsoft.EntityFrameworkCore.Internal;

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

        #region observablecollections
        private List<Client> allClients;
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
        private List<Limousine> allLimousines;
        private ObservableCollection<Limousine> _limousines;
        public ObservableCollection<Limousine> Limousines
        {
            get { return _limousines; }
            set
            {
                _limousines = value; RaisePropertyChanged("Limousines");
            }
        }
        private List<Reservation> allReservations;
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
        VIPServicesRudyManager manager = new VIPServicesRudyManager(new UnitOfWork(new VIPServicesRudyContext()));
        public Client SelectedClient { get; set; }
        public Limousine SelectedLimousine { get; set; }
        public Array Categories { get; set; } = Enum.GetValues(typeof(CategorieType));
        public Array Locations { get; set; } = Enum.GetValues(typeof(Location));
        public string[] Arrangements { get; set; } = { "NightLife", "Wedding", "Wellness","Business","Aiport" };
        public string SelectedArrangement { get; set; }
        public Location SelectedStartLocation { get; set; }
        public Location SelectedArrivalLocation { get; set; }

        private Reservation reservation;
        public Reservation SelectedReservation { get; set; }
        public async Task InitializeClientsAsync() 
        {
            allClients = await Task.Run(() => manager.GetClients().ToList());
            Clients = new ObservableCollection<Client>(allClients);
        }
        public async Task InitializeLimousinesAsync() 
        {
            allLimousines = await Task.Run(() => manager.GetAllLimousine().ToList());
            Limousines = new ObservableCollection<Limousine>(allLimousines);
        }
        public async Task InitializeReservationsAsync() 
        {
            allReservations = await Task.Run(() => manager.GetReservations().ToList());
            Reservations = new ObservableCollection<Reservation>(allReservations);
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
                Client client = new Client(name, VATNumber, adres, manager.GetCategory(type));
                SelectedClient = client;
                return name;
        }

        public string GetPrice(string adres , DateTime reservationDateStart,DateTime reservationDateEnd) 
        {
            reservation = new Reservation(adres, SelectedClient, new ReservationDetails(reservationDateStart, reservationDateEnd, SelectedStartLocation, SelectedArrivalLocation, SelectedLimousine,GetSelectedArrangement(reservationDateStart,reservationDateEnd)));
            return reservation.PriceCalculation.Total.ToString() + "€";
        }
        private Arrangement GetSelectedArrangement(DateTime reservationDateStart, DateTime reservationDateEnd) 
        {
            switch (SelectedArrangement) 
            {
                case "NightLife":
                    return SelectedLimousine.FixedArrangements[0];
                case "Wedding":
                    return SelectedLimousine.FixedArrangements[1];
                case "Wellness":
                    return SelectedLimousine.FixedArrangements[2];
                case "Business":
                    return new HourlyArrangement(SelectedLimousine.FirstHourPrice, HourlyArrangementType.Business, reservationDateStart, reservationDateEnd);
                case "Aiport":
                    return new HourlyArrangement(SelectedLimousine.FirstHourPrice, HourlyArrangementType.Airport, reservationDateStart, reservationDateEnd);
                default:
                    return null;
            }
        }
        public async Task AddReservation() 
        {
            await Task.Run(() => manager.AddReservation(reservation));
        }
        public string ShowReservation() 
        {
            return reservation.ToString();
        }

        public void SearchClient(string input)
        {
            if (input.Length == 0)
                Clients = new ObservableCollection<Client>(allClients);
            else if (int.TryParse(input, out int nr))
                Clients = new ObservableCollection<Client>(allClients.Where(c => c.ClientNumber == nr));
            else if (input.StartsWith("BE"))
                Clients = new ObservableCollection<Client>(allClients.Where(c => c.VATNumber.ToLower().Contains(input.ToLower())));
            else if (input.Contains("-"))
                Clients = new ObservableCollection<Client>(allClients.Where(c => c.Adres.Contains(input)));
            else if (Enum.TryParse<CategorieType>(input,out CategorieType result))
                Clients = new ObservableCollection<Client>(allClients.Where(c => c.Categorie.Name == result));
            else
                Clients = new ObservableCollection<Client>(allClients.Where(c => c.Name.ToLower().Contains(input.ToLower())));
        }
        public void SearchLimo(string input) 
        {
            if (input.Length == 0)
                Limousines = new ObservableCollection<Limousine>(allLimousines);
            else
                Limousines = new ObservableCollection<Limousine>(allLimousines.Where(l => l.Name.ToLower().Contains(input.ToLower())));
        }
        public void SearchReservation(string input) 
        {
            if (DateTime.TryParse(input, out DateTime reservatieDatum))
                Reservations = new ObservableCollection<Reservation>(allReservations.Where(r => r.ReservationDate.Date.Equals(reservatieDatum.Date)));
            else
                Reservations = new ObservableCollection<Reservation>(allReservations.Where(r => r.Client.Name.ToLower().Contains(input.ToLower())));
        }

    }
}
