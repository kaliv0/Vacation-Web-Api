namespace Vacation.Domain.Entities
{
    public class Country : BaseEntity
    {
        public Country(string name)
            : base(name)
        {
        }

        public Country(int id, string name)
            : base(id, name)
        {
        }

        public virtual ICollection<City> Cities { get; } 
            //= new HashSet<City>();
    }
}