namespace Vacation.Domain.Entities
{
    public class Place : BaseEntity
    {
        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
