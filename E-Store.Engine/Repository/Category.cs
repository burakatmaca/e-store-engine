namespace E_Store.Engine.Repository
{
    partial class Category : BaseRepository<Entity.Designer.Category>
    {
        public Category(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
            : base(dataContext, repositoryContext, userContext) { }
    }
}
