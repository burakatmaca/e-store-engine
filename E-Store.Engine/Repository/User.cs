namespace E_Store.Engine.Repository
{
    partial class User : BaseRepository<Entity.Designer.User>
    {
        public User(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
            : base(dataContext, repositoryContext, userContext) { }
    }
}
