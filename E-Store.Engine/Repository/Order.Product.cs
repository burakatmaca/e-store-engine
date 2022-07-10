namespace E_Store.Engine.Repository
{
    partial class Order
    {
        internal partial class Product : BaseRepository<Entity.Designer.Order.Product>
        {
            public Product(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
                : base(dataContext, repositoryContext, userContext) { }
        }
    }
}
