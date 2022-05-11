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
                new Citizen(1, "Raphael Sanzio", 1),
                new Citizen(2, "Dante Alighieri", 2),
                new Citizen(3, "Max Schreck", 3),
                new Citizen(4, "Voltaire", 4),
                new Citizen(5, "Aristotle", 5));
        }
    }
}
