namespace E_Store.Engine.Repository
{
    partial class Project : BaseRepository<Entity.Designer.Project>
    {
        public Project(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
            : base(dataContext, repositoryContext, userContext) { }
    }
}
