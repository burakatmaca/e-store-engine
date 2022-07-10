namespace E_Store.Engine.Repository
{
    partial class City
    {
        internal partial class Town : BaseRepository<Entity.Designer.City.Town>
        {
            public Town(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
                : base(dataContext, repositoryContext, userContext) { }
        }
    }
}
