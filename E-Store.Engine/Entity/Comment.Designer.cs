using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Comment> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Comment");
                entity.Property(p => p.OwnerId).HasField("Owner_Id");
                entity.Property(p => p.Author).HasMaxLength(75);
                entity.Property(p => p.Email).HasMaxLength(100);

                entity.HasIndex(p => p.OwnerId);
                entity.HasIndex(p => p.IsApproved);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Comment : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
    }
}