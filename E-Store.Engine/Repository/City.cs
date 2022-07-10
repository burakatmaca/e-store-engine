namespace E_Store.Engine.Repository
{
    partial class City : BaseRepository<Entity.Designer.City>
    {
        public City(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
            : base(dataContext, repositoryContext, userContext) { }
    }
}
