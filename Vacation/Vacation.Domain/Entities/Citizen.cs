namespace Vacation.Domain.Entities
{
    public class Citizen : BaseEntity
    {
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; } = new HashSet<Achievement>();
    }
}
