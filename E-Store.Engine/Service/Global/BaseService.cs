namespace E_Store.Engine.Service
{
    public abstract class BaseService
    {
        internal Repository.IRepositoryContext RepositoryContext { get; private set; }
        internal IUserContext UserContext { get; private set; }

        public BaseService(Entity.DatabaseContext dataContext, IUserContext userContext)
        {
            this.UserContext = userContext;
            this.RepositoryContext = new Repository.RepositoryContext(dataContext, userContext);
        }
    }
}
