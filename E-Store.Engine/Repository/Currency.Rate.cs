namespace E_Store.Engine.Repository
{
    partial class Currency
    {
        internal partial class Rate : BaseRepository<Entity.Designer.Currency.Rate>
        {
            public Rate(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
                : base(dataContext, repositoryContext, userContext) { }
        }
    }
}
