using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Infrastructure.Data.Configuration
{
    /// <summary>
    ///  PartySymbolConfiguration
    /// </summary>
    public class PartySymbolConfiguration : IEntityTypeConfiguration<PartySymbol>
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<PartySymbol> builder)
        {
            builder.Property(x=>x.Code).IsRequired().HasMaxLength(128);
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(256);
        }
    }
}