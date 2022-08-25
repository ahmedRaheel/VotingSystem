using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Infrastructure.Data.Configuration
{
    /// <summary>
    ///  PartyConfiguration
    /// </summary>
    public class PartyConfiguration : IEntityTypeConfiguration<Party>
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Party> builder)
        {
            builder.Property(x=>x.FullName).IsRequired().HasMaxLength(512);
            builder.Property(x=>x.ShortName).IsRequired().HasMaxLength(256);
        }
    }
}