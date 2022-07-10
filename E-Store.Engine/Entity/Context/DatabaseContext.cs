using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace E_Store.Engine.Entity
{
    public class DatabaseContext : DbContext
    {
        ~DatabaseContext()
        {
            GC.SuppressFinalize(this);
        }
        public DatabaseContext() : this(null) { }
        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Designer.Banner>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Category>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Category.Feature>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Currency>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Currency.Rate>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.City>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.City.Town>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Comment>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Media>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Page>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Product>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Product.Category>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Product.Feature>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Project>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Router>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Offer>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Offer.Status>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Order>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Order.Product>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.Order.Status>(e => e.EntityConfiguration());
            modelBuilder.Entity<Designer.User>(e => e.EntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #region # exclude public
        public override int SaveChanges()
            => throw new NotImplementedException();
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
            => throw new NotImplementedException();
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => throw new NotImplementedException();
        #endregion

        internal int Save()
            => base.SaveChanges();
        internal int Save(bool acceptAllChangesOnSuccess)
            => base.SaveChanges(acceptAllChangesOnSuccess);
        internal Task<int> SaveAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
            => base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        internal Task<int> SaveAsync(CancellationToken cancellationToken = default)
            => base.SaveChangesAsync(cancellationToken);
    }
}
