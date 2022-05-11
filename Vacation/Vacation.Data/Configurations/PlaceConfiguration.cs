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
                new Place { Id = 1, Name = "Vatican", CityId = 1 },
                new Place { Id = 2, Name = "Colosseum", CityId = 1 },
                new Place { Id = 3, Name = "Uffizi", CityId = 2 },
                new Place { Id = 4, Name = "Brandenburg gate", CityId = 3 },
                new Place { Id = 5, Name = "Le Louvre", CityId = 4 },
                new Place { Id = 6, Name = "L'Arc de triomphe", CityId = 4 },
                new Place { Id = 7, Name = "Acropolis", CityId = 5 });
        }
    }
}
