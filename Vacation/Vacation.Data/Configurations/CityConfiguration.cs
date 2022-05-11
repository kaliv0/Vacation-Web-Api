using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacation.Domain.Entities;

namespace Vacation.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(nameof(City));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(c => c.Country)
                .WithMany(cn => cn.Cities)
                .IsRequired()
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.PlacesToVisit)
                .WithOne(p => p.City);

            builder.HasMany(c => c.FamousCitizens)
                .WithOne(fc => fc.City);

            builder.HasData(
                new City { Id = 1, Name = "Rome", CountryId = 1 },
                new City { Id = 2, Name = "Florence", CountryId = 1 },
                new City { Id = 3, Name = "Berlin", CountryId = 2 },
                new City { Id = 4, Name = "Paris", CountryId = 3 },
                new City { Id = 5, Name = "Athens", CountryId = 4 });
        }
    }
}
