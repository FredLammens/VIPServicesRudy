using System;
using System.ComponentModel.DataAnnotations;

namespace DomainLibrary.Domain.Limousines.Hours
{

    public static class HoursInfo
    {
        //eventueel in settings.json ??
        //helpermethods hier toevoegen ?
        public static float nightHourPercentage = 1.40f;
        public static TimeSpan nightHourStart = new TimeSpan(22, 00, 00);
        public static TimeSpan nightHourEnd = new TimeSpan(06, 00, 00);//7u not included so 6
        public static float restHourPercentage = 0.65f;
        public static float secondHourPercentage = 0.65f;
    }
    public enum HourType
    {
        EersteUur,
        TweedeUur,
        OverUur,
        NachtUur,
        VastePrijs
    }
    public class Hour
    {
        [Key]
        public int Id { get; private set; }
        public HourType HourType { get; private set; }
        public int Period { get; private set; }
        public int UnitPrice { get; private set; }

        public Hour(HourType hourType, int period, int unitPrice)
        {
            HourType = hourType;
            Period = period;
            SetUnitPrice(HourType, unitPrice);
        }
        private void SetUnitPrice(HourType hourtype, int unitPrice)
        {
            switch (hourtype)
            {
                case HourType.EersteUur:
                    UnitPrice = unitPrice;
                    break;
                case HourType.TweedeUur:
                    UnitPrice = HelperMethods.RoundtoFive(unitPrice * HoursInfo.secondHourPercentage);
                    break;
                case HourType.OverUur:
                    UnitPrice = HelperMethods.RoundtoFive(unitPrice * HoursInfo.restHourPercentage);
                    break;
                case HourType.NachtUur:
                    UnitPrice = HelperMethods.RoundtoFive(unitPrice * HoursInfo.nightHourPercentage);
                    break;
                case HourType.VastePrijs:
                    UnitPrice = unitPrice;
                    break;
            }
        }
    }
}
