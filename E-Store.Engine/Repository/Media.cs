namespace E_Store.Engine.Repository
{
    partial class Media : BaseRepository<Entity.Designer.Media>
    {
        public Media(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
            : base(dataContext, repositoryContext, userContext) { }
    }
}