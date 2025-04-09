using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ConfigurationConfiguration : IEntityTypeConfiguration<Domain.Entities.Configuration>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Configuration> builder)
        {
            builder.ToTable("Configuration");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Value).IsRequired().HasMaxLength(800);
            builder.Property(u => u.Description);
        }

    }
}
