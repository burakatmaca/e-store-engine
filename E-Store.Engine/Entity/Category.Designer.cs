using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Category> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Category");
                entity.Property(p => p.ParentId).HasField("Parent_Id");
                entity.Property(p => p.Code).HasMaxLength(10);
                entity.Property(p => p.Name).HasMaxLength(50);
                entity.Property(p => p.Url).HasMaxLength(250);
                entity.Property(p => p.MetaTitle).HasMaxLength(100);

                entity.HasIndex(p => p.ParentId);
                entity.HasIndex(p => p.IsActive);
                entity.HasIndex(p => p.Code).IsUnique();
                entity.HasIndex(p => p.Url).IsUnique();
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Category : BaseEntity
    {
        public Guid? ParentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sort { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }

        public virtual ICollection<Designer.Category.Feature> Features { get; set; }
        public virtual ICollection<Designer.Product.Category> Products { get; set; }

        public Category()
        {
            this.Features = new HashSet<Designer.Category.Feature>();
        }
    }
}