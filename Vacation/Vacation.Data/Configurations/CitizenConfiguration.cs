using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacation.Domain.Entities;

namespace Vacation.Data.Configurations
{
    public class CitizenConfiguration : IEntityTypeConfiguration<Citizen>
    {
        public void Configure(EntityTypeBuilder<Citizen> builder)
        {
            builder.ToTable(nameof(Citizen));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(c => c.City)
                .WithMany(ct => ct.FamousCitizens)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Achievements)
                .WithOne(a => a.Citizen);

            builder.HasData(
                new Citizen { Id = 1, Name = "Raphael Sanzio", CityId = 1 },
                new Citizen { Id = 2, Name = "Dante Alighieri", CityId = 2 },
                new Citizen { Id = 3, Name = "Max Schreck", CityId = 3 },
                new Citizen { Id = 4, Name = "Voltaire", CityId = 4 },
                new Citizen { Id = 5, Name = "Aristotle", CityId = 5 });
        }
    }
}
