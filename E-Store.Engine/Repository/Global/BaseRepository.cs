using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace E_Store.Engine.Repository
{
    #region # interface
    interface IBaseRepository<TEntity> where TEntity : Entity.Designer.BaseEntity
    {
        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> clause);
        Task<TEntity> FindOne(Expression<Func<TEntity, bool>> clause, CancellationToken cancelationToken);
        Task<int> Insert(TEntity entity, CancellationToken cancelationToken);
        Task<int> Update(TEntity entity, CancellationToken cancelationToken);
        Task<int> Delete(Guid id, CancellationToken cancelationToken);
        Task<int> Delete(Expression<Func<TEntity, bool>> clause, CancellationToken cancelationToken);
    }
    #endregion

    abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity.Designer.BaseEntity
    {
        readonly DbSet<TEntity> _dataSet;
        readonly Entity.DatabaseContext _dataContext;

        public IUserContext User { get; private set; }
        public IRepositoryContext Repository { get; private set; }

        public BaseRepository(Entity.DatabaseContext dbContext, IRepositoryContext repositoryContext, IUserContext userContext)
        {
            User = userContext;
            Repository = repositoryContext;
            _dataContext = dbContext;
            _dataSet = _dataContext.Set<TEntity>();
        }

        #region # find methods
        public virtual IQueryable<TEntity> FindAll()
            => _dataSet.AsNoTracking();
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> clause)
            => clause != null ? FindAll().Where(clause) : FindAll();
        public virtual async Task<TEntity> FindOne(Expression<Func<TEntity, bool>> clause, CancellationToken cancelationToken)
            => await Find(clause).FirstOrDefaultAsync(cancelationToken);
        #endregion

        #region # set methods
        public virtual async Task<int> Insert(TEntity entity, CancellationToken cancelationToken)
        {
            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            entity.CreatedById = User?.Id ?? Guid.Empty;
            entity.CreatedDate = DateTime.UtcNow;

            var msgs = await Validate(RecordActionTypes.Insert, entity, cancelationToken);
            if (msgs?.Length > 0)
                throw new ValidationException(string.Join(Environment.NewLine, msgs));

            var entry = _dataSet.Add(entity);
            entry.State = EntityState.Added;
            var ret = await _dataContext.SaveAsync(cancelationToken);
            entry.State = EntityState.Detached;
            return ret;
        }
        public virtual async Task<int> Update(TEntity entity, CancellationToken cancelationToken)
        {
            entity.UpdatedById = User?.Id ?? Guid.Empty;
            entity.UpdatedDate = DateTime.UtcNow;

            var msgs = await Validate(RecordActionTypes.Update, entity, cancelationToken);
            if (msgs?.Length > 0)
                throw new ValidationException(string.Join(Environment.NewLine, msgs));

            var entry = _dataSet.Update(entity);
            entry.State = EntityState.Modified;
            var ret = await _dataContext.SaveAsync(cancelationToken);
            entry.State = EntityState.Detached;
            return ret;
        }
        public virtual async Task<int> Delete(Guid id, CancellationToken cancelationToken)
        {
            var entity = await this.FindOne(p => p.Id == id, cancelationToken);

            var msgs = await this.Validate(RecordActionTypes.Delete, entity, cancelationToken);
            if (msgs?.Length > 0)
                throw new ValidationException(string.Join(Environment.NewLine, msgs));

            var entry = _dataSet.Remove(entity);
            entry.State = EntityState.Deleted;
            var ret = await _dataContext.SaveAsync(cancelationToken);
            entry.State = EntityState.Detached;
            return ret;
        }
        public virtual async Task<int> Delete(Expression<Func<TEntity, bool>> clause, CancellationToken cancelationToken)
        {
            var entities = await Find(clause).ToListAsync();

            var entries = new List<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity>>();
            foreach (var entity in entities)
            {
                var msgs = await Validate(RecordActionTypes.Delete, entity, cancelationToken);
                if (msgs?.Length > 0)
                    throw new ValidationException(string.Join(Environment.NewLine, msgs));

                var entry = _dataSet.Remove(entity);
                entry.State = EntityState.Deleted;
                entries.Add(entry);
            }

            var ret = await _dataContext.SaveAsync(cancelationToken);
            foreach (var e in entries)
                e.State = EntityState.Detached;
            return ret;
        }
        #endregion

        protected internal virtual Task<string[]> Validate(RecordActionTypes type, TEntity entity, CancellationToken cancelationToken)
            => Task.FromResult(Array.Empty<string>());
    }

    enum RecordActionTypes
    {
        Insert,
        Update,
        Delete
    }
}
