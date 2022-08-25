using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Infrastructure.Data.Configuration
{
    /// <summary>
    ///  StateConfiguration
    /// </summary>
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.Property(x=>x.Code).IsRequired().HasMaxLength(128);
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(256);
            builder.HasMany(x=>x.Cities);
        }
    }
}