namespace E_Store.Engine.Repository
{
    partial class Currency : BaseRepository<Entity.Designer.Currency>
    {
        public Currency(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
            : base(dataContext, repositoryContext, userContext) { }
    }
}
