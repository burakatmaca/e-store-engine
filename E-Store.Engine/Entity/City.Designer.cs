using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.City> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("City");
                entity.Property(p => p.Name).HasMaxLength(5);
                entity.Property(p => p.Name).HasMaxLength(100);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class City : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Designer.City.Town> Towns { get; set; }
        public virtual ICollection<Designer.Order> OrderInvoices { get; set; }
        public virtual ICollection<Designer.Order> OrderShippings { get; set; }
    }
}