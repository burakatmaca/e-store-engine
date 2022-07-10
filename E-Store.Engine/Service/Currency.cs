namespace E_Store.Engine.Service
{
    public interface ICurrency
    {

    }

    public class Currency : BaseService, ICurrency
    {
        public Currency(Entity.DatabaseContext databaseContext, IUserContext userContext)
            : base(databaseContext, userContext) { }
    }
}
