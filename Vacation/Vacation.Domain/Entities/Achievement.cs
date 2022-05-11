namespace Vacation.Domain.Entities
{
    public class Achievement : BaseEntity
    {
        public Achievement(int id, string name, int citizenId)
            : base(id, name)
        {
            this.CitizenId = citizenId;
        }

        public int CitizenId { get; set; }

        public virtual Citizen Citizen { get; set; }
    }
}
