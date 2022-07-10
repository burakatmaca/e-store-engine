namespace E_Store.Engine.Service
{
    public interface ICity
    {

    }

    public class City : BaseService, ICity
    {
        public City(Entity.DatabaseContext databaseContext, IUserContext userContext)
            : base(databaseContext, userContext) { }
    }
}
