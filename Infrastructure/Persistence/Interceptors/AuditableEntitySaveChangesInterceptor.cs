using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VotingSystem.Domain.Common;
using VotingSystem.Infrastructure.Persistence.Extensions;

namespace VotingSystem.Infrastructure.Persistence.Interceptors
{
    /// <summary>
    ///     AuditableEntitySaveChangesInterceptor
    /// </summary>
    public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public AuditableEntitySaveChangesInterceptor()
        {
        }
        
        /// <summary>
        ///     SavingChanges
        /// </summary>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }
        
        /// <summary>
        ///     SavingChangesAsync
        /// </summary>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        private void UpdateEntities(DbContext? context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = "TestUser"; 
                    entry.Entity.Created = DateTime.UtcNow;
                } 

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                {
                    entry.Entity.LastModifiedBy = "TestUser";
                    entry.Entity.LastModified = DateTime.UtcNow;
                }
            }
       }
    }
}