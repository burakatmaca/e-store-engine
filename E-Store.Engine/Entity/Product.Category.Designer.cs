using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Product.Category> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Product_Category");
                entity.Property(p => p.ProductId).HasField("Product_Id");
                entity.Property(p => p.CategoryId).HasField("Category_Id");

                entity.HasIndex(p => new { p.ProductId, p.CategoryId }).IsUnique();
                entity.HasOne(p => p.Product).WithMany(p => p.Categories).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(p => p.Category_).WithMany(p => p.Products).OnDelete(DeleteBehavior.Cascade);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Product
    {
        internal partial class Category : BaseEntity
        {
            public Guid ProductId { get; set; }

            public Guid CategoryId { get; set; }
            public int Sort { get; set; }

            [ForeignKey(nameof(ProductId))]
            public virtual Designer.Product Product { get; set; }

            [ForeignKey(nameof(CategoryId))]
            public virtual Designer.Category Category_ { get; set; }
        }
    }
}