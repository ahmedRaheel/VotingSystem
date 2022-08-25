using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Infrastructure.Data.Configuration
{
    /// <summary>
    ///  VoterConfiguration
    /// </summary>
    public class VoterConfiguration : IEntityTypeConfiguration<Voter>
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Voter> builder)
        {
            builder.Property(x =>x.CNIC).IsRequired().HasMaxLength(64);
            builder.Property(x=>x.FirstName).IsRequired().HasMaxLength(256);
            builder.Property(x=>x.LastName).IsRequired().HasMaxLength(256);
            builder.Property(x=>x.FatherName).IsRequired().HasMaxLength(256);
            builder.Property(x=>x.HomePhone).HasMaxLength(32);
            builder.Property(x=>x.MobileNumber).HasMaxLength(32);
        }
    }
}