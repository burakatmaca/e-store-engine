using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Category.Feature> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Category_Feature");
                entity.Property(p => p.CategoryId).HasField("Category_Id");
                entity.Property(p => p.Name).HasMaxLength(50);


                entity.HasIndex(p => new { p.IsActive, p.IsFilter });
                entity.HasOne(p => p.Category).WithMany(p => p.Features).OnDelete(DeleteBehavior.Cascade);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Category
    {
        internal partial class Feature : BaseEntity
        {
            public Guid CategoryId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Sort { get; set; }
            public bool IsActive { get; set; }
            public bool IsFilter { get; set; }

            [ForeignKey(nameof(CategoryId))]
            public virtual Designer.Category Category { get; set; }

            public virtual ICollection<Designer.Product.Feature> Products { get; set; }
        }
    }
}