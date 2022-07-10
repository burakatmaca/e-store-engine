using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Product.Feature> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Product_Feature");
                entity.Property(p => p.ProductId).HasField("Product_Id");
                entity.Property(p => p.CategoryFeatureId).HasField("Category_Feature_Id");
                entity.Property(p => p.Value).HasMaxLength(100);

                entity.HasIndex(p => new { p.ProductId, p.CategoryFeatureId }).IsUnique();
                entity.HasOne(p => p.Product).WithMany(p => p.Features).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(p => p.CategoryFeature).WithMany(p => p.Products).OnDelete(DeleteBehavior.Cascade);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Product
    {
        internal partial class Feature : BaseEntity
        {
            public Guid ProductId { get; set; }
            public Guid CategoryFeatureId { get; set; }
            public string Value { get; set; }

            [ForeignKey(nameof(ProductId))]
            public virtual Designer.Product Product { get; set; }

            [ForeignKey(nameof(CategoryFeatureId))]
            public virtual Designer.Category.Feature CategoryFeature { get; set; }
        }
    }
}