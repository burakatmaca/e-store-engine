namespace E_Store.Engine.Repository
{
    partial class Product
    {
        internal partial class Category : BaseRepository<Entity.Designer.Product.Category>
        {
            public Category(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
                : base(dataContext, repositoryContext, userContext) { }
        }
    }
}
