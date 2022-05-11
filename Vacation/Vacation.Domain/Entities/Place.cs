namespace Vacation.Domain.Entities
{
    public class Place : BaseEntity
    {
        public Place(int id, string name, int cityId)
            : base(id, name)
        {
            this.CityId = cityId;
        }

        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
