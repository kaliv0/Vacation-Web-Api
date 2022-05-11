using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacation.Domain.Entities;

namespace Vacation.Data.Configurations
{
    public class AchievementConfiguration : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> builder)
        {
            builder.ToTable(nameof(Achievement));

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(a => a.Citizen)
                .WithMany(c => c.Achievements)
                .HasForeignKey(a => a.CitizenId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Achievement(1, "Sposalizio", 1),
                new Achievement(2, "La divina commedia", 2),
                new Achievement(3, "Das Cabinet von Dr. Caligari", 3),
                new Achievement(4, "Candid", 4),
                new Achievement(5, "Ethics", 5));
        }
    }
}
