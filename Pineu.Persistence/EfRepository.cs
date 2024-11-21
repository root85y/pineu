using Ardalis.Specification.EntityFrameworkCore;
using Pineu.Domain.Entities.Primitives;
using Pineu.Persistence.Context;

namespace Pineu.Persistence {
    public class EfRepository<T, TKey>(ApplicationDbContext dbContext)
        : RepositoryBase<T>(dbContext), IReadRepository<T, TKey>, IRepository<T, TKey>
        where T : Entity<TKey> {
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
            OverrideUpdate();
            OverrideDelete();
            var res = await base.SaveChangesAsync(cancellationToken);
            dbContext.ChangeTracker.Clear();
            return res;
        }

        public void OverrideUpdate() {
            var modifiedEntries = dbContext.ChangeTracker.Entries<Entity<TKey>>().Where(e =>
                e.State == EntityState.Modified
            );

            foreach (var item in modifiedEntries) {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

                var updatedAt = entityType?.FindProperty("UpdatedAt");

                if (updatedAt == null) continue;
                item.Property("UpdatedAt").CurrentValue = DateTime.Now;
                item.State = EntityState.Modified;
            }
        }

        private void OverrideDelete() {
            var modifiedEntries = dbContext.ChangeTracker.Entries<Entity<TKey>>().Where(e =>
                e.State == EntityState.Deleted
            );

            foreach (var item in modifiedEntries) {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

                var removedAt = entityType?.FindProperty("DeletedAt");

                if (removedAt == null) continue;
                item.Property("DeletedAt").CurrentValue = DateTime.Now;
                item.State = EntityState.Modified;
            }
        }
    }
}