using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Infrastructure.Data.Configuration
{
    /// <summary>
    ///  CandidateConfiguration
    /// </summary>
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(x =>x.CNIC).HasMaxLength(64);
            builder.Property(x=>x.FirstName).HasMaxLength(256);
            builder.Property(x=>x.LastName).HasMaxLength(256);
            builder.Property(x=>x.FatherName).HasMaxLength(256);
            builder.Property(x=>x.HomePhone).HasMaxLength(32);
            builder.Property(x=>x.MobileNumber).HasMaxLength(32);
        }
    }
}