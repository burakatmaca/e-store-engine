namespace E_Store.Engine.Repository
{
    partial class Offer : BaseRepository<Entity.Designer.Offer>
    {
        public Offer(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
            : base(dataContext, repositoryContext, userContext) { }
    }
}
