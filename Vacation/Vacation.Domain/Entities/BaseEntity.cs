namespace Vacation.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public BaseEntity(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
