namespace E_Store.Engine.Repository
{
    partial class Banner : BaseRepository<Entity.Designer.Banner>
    {
        public Banner(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
            : base(dataContext, repositoryContext, userContext) { }
    }
}