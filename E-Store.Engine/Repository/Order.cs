namespace E_Store.Engine.Repository
{
    partial class Order : BaseRepository<Entity.Designer.Order>
    {
        public Order(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
            : base(dataContext, repositoryContext, userContext) { }
    }
}
