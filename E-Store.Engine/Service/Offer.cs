namespace E_Store.Engine.Service
{
    public interface IOffer
    {

    }

    public class Offer : BaseService, IOffer
    {
        public Offer(Entity.DatabaseContext databaseContext, IUserContext userContext)
            : base(databaseContext, userContext) { }
    }
}
