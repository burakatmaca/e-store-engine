namespace E_Store.Engine.Repository
{
    partial class Order
    {
        internal partial class Status : BaseRepository<Entity.Designer.Order.Status>
        {
            public Status(Entity.DatabaseContext dataContext, IRepositoryContext repositoryContext, IUserContext userContext)
                : base(dataContext, repositoryContext, userContext) { }
        }
    }
}
