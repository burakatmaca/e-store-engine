namespace E_Store.Engine.Service
{
    public interface ICategory
    {

    }

    public class Category : BaseService, ICategory
    {
        public Category(Entity.DatabaseContext databaseContext, IUserContext userContext)
            : base(databaseContext, userContext) { }
    }
}
