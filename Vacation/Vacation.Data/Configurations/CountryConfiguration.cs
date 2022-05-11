using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacation.Domain.Entities;

namespace Vacation.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(nameof(Country));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(c => c.Cities)
                .WithOne(c => c.Country);


            builder.HasData(
                new Country(1, "Italy"),
                new Country(2, "Germany"),
                new Country(3, "France"),
                new Country(4, "Greece"));
        }
    }
}
