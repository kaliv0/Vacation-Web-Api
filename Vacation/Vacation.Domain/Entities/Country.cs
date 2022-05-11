namespace Vacation.Domain.Entities
{
    public class Country : BaseEntity
    {
        public virtual ICollection<City> Cities { get; } = new HashSet<City>();
    }
}