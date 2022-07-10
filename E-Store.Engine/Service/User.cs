namespace E_Store.Engine.Service
{
    public interface IUser
    {

    }

    public class User : BaseService, IUser
    {
        public User(Entity.DatabaseContext databaseContext, IUserContext userContext)
            : base(databaseContext, userContext) { }
    }
}
