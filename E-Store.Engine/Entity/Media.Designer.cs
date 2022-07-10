using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Media> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Media");
                entity.Property(p => p.OwnerId).HasField("Owner_Id");
                entity.Property(p => p.Path).HasMaxLength(250);
                entity.Property(p => p.MimeType).HasMaxLength(50);

                entity.HasIndex(p => p.OwnerId);
                entity.HasIndex(p => p.IsDefault);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Media : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public int Sort { get; set; }
        public bool IsDefault { get; set; }
        public MediaTypes Type { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
    }

    enum MediaTypes
    {
        Picture = 0,
        Video = 1
    }
}