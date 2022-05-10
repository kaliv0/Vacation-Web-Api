namespace Vacation.Domain.Dtos
{
    public class BaseDto
    {
        public BaseDto(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
