namespace Vacation.Domain.Entities
{
    public class Citizen : BaseEntity
    {
        public Citizen(int id, string name, int cityId)
            : base(id, name)
        {
            this.CityId = cityId;
        }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
    }
}
