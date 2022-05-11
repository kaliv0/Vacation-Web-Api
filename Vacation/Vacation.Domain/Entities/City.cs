namespace Vacation.Domain.Entities
{
    public class City:BaseEntity
    {
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Place> PlacesToVisit { get; set; }

        public virtual ICollection<Citizen> FamousCitizens { get; set; }
    }
}
