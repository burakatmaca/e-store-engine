namespace E_Store.Engine.Repository
{
    partial class Comment : BaseRepository<Entity.Designer.Comment>
    {
        public Comment(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
            : base(dataContext, repositoryContext, userContext) { }
    }
}