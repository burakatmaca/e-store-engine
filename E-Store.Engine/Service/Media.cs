namespace E_Store.Engine.Service
{
    public interface IMedia
    {

    }

    public class Media : BaseService, IMedia
    {
        public Media(Entity.DatabaseContext databaseContext, IUserContext userContext)
            : base(databaseContext, userContext) { }
    }
}
