namespace E_Store.Engine.Repository
{
    partial class Product : BaseRepository<Entity.Designer.Product>
    {
        public Product(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
            : base(dataContext, repositoryContext, userContext) { }
    }
}
