namespace E_Store.Engine.Service
{
    public interface IProject
    {
    }

    public class Project : BaseService, IProject
    {
        public Project(Entity.DatabaseContext databaseContext, IUserContext userContext)
            : base(databaseContext, userContext) { }
    }
}
