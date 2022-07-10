namespace E_Store.Engine.Service
{
    public interface IRouter
    {

    }

    public class Router : BaseService, IRouter
    {
        public Router(Entity.DatabaseContext databaseContext, IUserContext userContext)
            : base(databaseContext, userContext) { }
    }
}
