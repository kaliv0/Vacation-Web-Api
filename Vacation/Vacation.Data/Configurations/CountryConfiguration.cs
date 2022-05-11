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
                new Country { Id = 1, Name = "Italy" },
                new Country { Id = 2, Name = "Germany" },
                new Country { Id = 3, Name = "France" },
                new Country { Id = 4, Name = "Greece" });
        }
    }
}
