using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingSystem.Domain.Entities;

namespace VotingSystem.Infrastructure.Data.Configuration
{
    /// <summary>
    ///  CityConfiguration
    /// </summary>
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x=> x.Code).IsRequired().HasMaxLength(128);
            builder.Property(x=> x.Name).IsRequired().HasMaxLength(256);
        }
    }
}