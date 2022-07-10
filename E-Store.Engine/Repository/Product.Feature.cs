namespace E_Store.Engine.Repository
{
    partial class Product
    {
        internal partial class Feature : BaseRepository<Entity.Designer.Product.Feature>
        {
            public Feature(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
                : base(dataContext, repositoryContext, userContext) { }
        }
    }
}
