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
                new Achievement { Id = 1, Name = "Sposalizio", CitizenId = 1 },
                new Achievement { Id = 2, Name = "La divina commedia", CitizenId = 2 },
                new Achievement { Id = 3, Name = "Das Cabinet von Dr. Caligari", CitizenId = 3 },
                new Achievement { Id = 4, Name = "Candid", CitizenId = 4 },
                new Achievement { Id = 5, Name = "Ethics", CitizenId = 5 });
        }
    }
}
