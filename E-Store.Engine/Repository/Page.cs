namespace E_Store.Engine.Repository
{
    partial class Page : BaseRepository<Entity.Designer.Page>
    {
        public Page(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
            : base(dataContext, repositoryContext, userContext) { }
    }
}
