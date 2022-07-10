namespace E_Store.Engine.Repository
{
    partial class Category
    {
        internal partial class Feature : BaseRepository<Entity.Designer.Category.Feature>
        {
            public Feature(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
                : base(dataContext, repositoryContext, userContext) { }
        }
    }
}
