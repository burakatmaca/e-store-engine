namespace E_Store.Engine.Service
{
    public interface IPage
    {

    }

    public class Page : BaseService, IPage
    {
        public Page(Entity.DatabaseContext databaseContext, IUserContext userContext)
            : base(databaseContext, userContext) { }
    }
}
