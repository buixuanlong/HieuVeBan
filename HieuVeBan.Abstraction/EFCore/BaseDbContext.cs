using HieuVeBan.Abstraction.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HieuVeBan.Abstraction.EFCore
{
    public class BaseDbContext : DbContext
    {
        private readonly IUserContext _userContext;

        protected BaseDbContext(IUserContext userContext)
        {
            _userContext = userContext;
        }

        protected BaseDbContext(DbContextOptions options, IUserContext userContext) : base(options)
        {
            _userContext = userContext;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateModificationHistory();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override int SaveChanges()
        {
            UpdateModificationHistory();
            return SaveChanges(true);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateModificationHistory();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateModificationHistory();
            return await SaveChangesAsync(true, cancellationToken);
        }


        #region Helpers

        protected virtual Type GetEntityConfigurationInterface(Type type)
        {
            return type.GetInterfaces().FirstOrDefault(inf => inf.IsConstructedGenericType
                && inf.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))!;
        }

        private void UpdateModificationHistory()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory
                    && e.State == EntityState.Modified)
                .Select(e => e.Entity as IModificationHistory);

            foreach (var entry in entries)
            {
                entry!.UpdatedDateTime = DateTime.UtcNow;
                entry.UpdatedUserId = _userContext.GetUserId();
            }
        }
        #endregion
    }
}
