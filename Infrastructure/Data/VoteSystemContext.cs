namespace VotingSystem.Infrastructure.Data
{
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;
    using VotingSystem.Domain.Entities;
    using VotingSystem.Infrastructure.Persistence.Interceptors;

    /// <summary>
    ///   VotingSystemContext
    /// </summary>
    public class VotingSystemContext : DbContext 
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="options"></param>
        public VotingSystemContext(DbContextOptions<VotingSystemContext> options,
                                  AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
                                  : base(options)
        {
             _auditableEntitySaveChangesInterceptor =  auditableEntitySaveChangesInterceptor;
        }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
         }

        public DbSet<State> State {get;set;}
        public DbSet<City> City {get;set;}
        public DbSet<PartySymbol> PartySymbol {get;set;}
        public DbSet<Party> Party { get;set;}
        public DbSet<CandidateCategory>  CandidateCategory {get;set;}
        public DbSet<Candidate>   Candidate   {get;set;}
        public DbSet<CandidateContact>  CandidateContact  {get;set;}
        public DbSet<Voter> Voter {get;set;}
        public DbSet<VoterContact> VoterContact {get;set;}
        public DbSet<VoteCast> VoteCast {get;set;}        
    }
}