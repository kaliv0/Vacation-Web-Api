namespace Vacation.Domain.Entities
{
    public class Country : BaseEntity
    {
        //public Country(int id, string name, ICollection<City> cities)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.Cities = cities;
        //}

        public virtual ICollection<City> Cities { get; }
    }
}