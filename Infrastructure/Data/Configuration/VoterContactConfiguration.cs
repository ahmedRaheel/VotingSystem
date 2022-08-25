using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Infrastructure.Data.Configuration
{
    /// <summary>
    ///  VoterContactConfiguration
    /// </summary>
    public class VoterContactConfiguration : IEntityTypeConfiguration<VoterContact>
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<VoterContact> builder)
        {
            builder.Property(x =>x.AddressLine).HasMaxLength(512);           
        }
    }
}