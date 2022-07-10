namespace E_Store.Engine.Service
{
    public interface IBanner
    {

    }

    public class Banner : BaseService, IBanner
    {
        public Banner(Entity.DatabaseContext databaseContext, IUserContext userContext)
            : base(databaseContext, userContext) { }
    }
}
