namespace E_Store.Engine.Service
{
    public interface IOrder
    {

    }

    public class Order : BaseService, IOrder
    {
        public Order(Entity.DatabaseContext databaseContext, IUserContext userContext)
            : base(databaseContext, userContext) { }
    }
}
