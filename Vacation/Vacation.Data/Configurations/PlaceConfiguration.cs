using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacation.Domain.Entities;

namespace Vacation.Data.Configurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable(nameof(Place));

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(p => p.City)
                .WithMany(c => c.PlacesToVisit)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Place(1, "Vatican", 1),
                new Place(2, "Colosseum", 1),
                new Place(3, "Uffizi", 2),
                new Place(4, "Brandenburg gate", 3),
                new Place(5, "Le Louvre", 4),
                new Place(6, "L'Arc de triomphe", 4),
                new Place(7, "Acropolis", 5));
        }
    }
}
