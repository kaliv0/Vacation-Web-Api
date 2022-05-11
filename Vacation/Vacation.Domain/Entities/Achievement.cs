namespace Vacation.Domain.Entities
{
    public class Achievement : BaseEntity
    {
        public int CitizenId { get; set; }

        public virtual Citizen Citizen { get; set; }
    }
}
