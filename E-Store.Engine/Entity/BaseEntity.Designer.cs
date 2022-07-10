using System;

namespace E_Store.Engine.Entity.Designer
{
    #region # interface
    interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime CreatedDate { get; set; }
        Guid CreatedById { get; set; }
        DateTime? UpdatedDate { get; set; }
        Guid? UpdatedById { get; set; }
    }
    #endregion

    abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedById { get; set; }
    }
}
