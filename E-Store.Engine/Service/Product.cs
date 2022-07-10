namespace E_Store.Engine.Service
{
    public interface IProduct
    {

    }

    public class Product : BaseService, IProduct
    {
        public Product(Entity.DatabaseContext databaseContext, IUserContext userContext)
            : base(databaseContext, userContext) { }
    }
}
