using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Infrastructure.Data.Configuration
{
    /// <summary>
    ///  CandidateContactConfiguration
    /// </summary>
    public class CandidateContactConfiguration : IEntityTypeConfiguration<CandidateContact>
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CandidateContact> builder)
        {
            builder.Property(x => x.AddressLine).HasMaxLength(512);          
        }
    }
}