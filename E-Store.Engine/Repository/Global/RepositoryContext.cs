using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Transactions;
using entity = E_Store.Engine.Entity;

namespace E_Store.Engine.Repository
{
    #region # interface
    partial interface IRepositoryContext
    {
        IBaseRepository<entity.Designer.Banner> Banners { get; }
        IBaseRepository<entity.Designer.Category> Categories { get; }
        IBaseRepository<entity.Designer.Category.Feature> CategoryFeatures { get; }
        IBaseRepository<entity.Designer.City> Cities { get; }
        IBaseRepository<entity.Designer.City.Town> CityTowns { get; }
        IBaseRepository<entity.Designer.Comment> Comments { get; }
        IBaseRepository<entity.Designer.Currency> Currencies { get; }
        IBaseRepository<entity.Designer.Currency.Rate> CurrencyRates { get; }
        IBaseRepository<entity.Designer.Media> Medias { get; }
        IBaseRepository<entity.Designer.Offer> Offers { get; }
        IBaseRepository<entity.Designer.Offer.Status> OfferStatuses { get; }
        IBaseRepository<entity.Designer.Order> Orders { get; }
        IBaseRepository<entity.Designer.Order.Product> OrderProducts { get; }
        IBaseRepository<entity.Designer.Order.Status> OrderStatuses { get; }
        IBaseRepository<entity.Designer.Page> Pages { get; }
        IBaseRepository<entity.Designer.Product.Category> ProductCategories { get; }
        IBaseRepository<entity.Designer.Product> Products { get; }
        IBaseRepository<entity.Designer.Product.Feature> ProductFeatures { get; }
        IBaseRepository<entity.Designer.Project> Projects { get; }
        IBaseRepository<entity.Designer.Router> Router { get; }
        IBaseRepository<entity.Designer.User> Users { get; }

        Task<bool> Transaction(Func<Task<bool>> action, IsolationLevel? isoLevel = null);
    }
    #endregion

    sealed class RepositoryContext : IRepositoryContext
    {
        readonly entity.DatabaseContext _databaseContext;
        readonly IUserContext _userContext;

        public RepositoryContext(entity.DatabaseContext databaseContext, IUserContext userContext)
        {
            this._userContext = userContext;
            this._databaseContext = databaseContext;
        }

        #region # repositories
        public IBaseRepository<entity.Designer.Banner> Banners
            => new Banner(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Category> Categories
            => new Category(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Category.Feature> CategoryFeatures
            => new Category.Feature(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.City> Cities
            => new City(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.City.Town> CityTowns
            => new City.Town(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Comment> Comments
            => new Comment(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Currency> Currencies
            => new Currency(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Currency.Rate> CurrencyRates
            => new Currency.Rate(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Media> Medias
            => new Media(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Offer> Offers
            => new Offer(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Offer.Status> OfferStatuses
            => new Offer.Status(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Order> Orders
            => new Order(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Order.Product> OrderProducts
            => new Order.Product(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Order.Status> OrderStatuses
            => new Order.Status(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Page> Pages
            => new Page(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Product.Category> ProductCategories
            => new Product.Category(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Product> Products
            => new Product(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Product.Feature> ProductFeatures
            => new Product.Feature(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Project> Projects
            => new Project(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.Router> Router
            => new Router(this._databaseContext, this, this._userContext);
        public IBaseRepository<entity.Designer.User> Users
            => new User(this._databaseContext, this, this._userContext);
        #endregion

        public async Task<bool> Transaction(Func<Task<bool>> action, IsolationLevel? isoLevel = null)
        {
            var everythingRight = false;
            await this._databaseContext.Database.CreateExecutionStrategy().Execute(async () =>
            {
                using var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
                {
                    IsolationLevel = isoLevel ?? IsolationLevel.ReadCommitted,
                    Timeout = TimeSpan.FromMinutes(2)
                }, TransactionScopeAsyncFlowOption.Enabled);

                try { everythingRight = await action?.Invoke(); }
                catch (System.ComponentModel.WarningException ex) { everythingRight = false; throw ex; }
                catch (System.ComponentModel.DataAnnotations.ValidationException ex) { everythingRight = false; throw ex; }
                catch (Exception) { everythingRight = false; throw; }
                finally
                {
                    if (!everythingRight)
                        transaction.Dispose();
                    else
                        transaction.Complete();
                }
            });
            return everythingRight;
        }
    }
}
