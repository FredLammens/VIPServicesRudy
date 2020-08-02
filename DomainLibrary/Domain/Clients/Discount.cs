using System.ComponentModel.DataAnnotations;

namespace DomainLibrary.Domain.Clients
{
    public class Discount //mischien overerven van Dictionary?
    {
        [Key]
        public int Id { get; set; }
        public int Aantal { get; private set; }
        public float Korting { get; private set; }

        public Discount(int aantal, float korting)
        {
            Aantal = aantal;
            Korting = korting;
        }
    }
}
