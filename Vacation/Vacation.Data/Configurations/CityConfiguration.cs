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
                new City(1, "Rome", 1),
                new City(2, "Florence", 1),
                new City(3, "Berlin", 2),
                new City(4, "Paris", 3),
                new City(5, "Athens", 4));
        }
    }
}
