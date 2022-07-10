using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.City.Town> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("City_Town");
                entity.Property(p => p.Name).HasMaxLength(5);
                entity.Property(p => p.Name).HasMaxLength(100);
                entity.Property(p => p.CityId).HasField("City_Id");

                entity.HasIndex(p => p.Code);
                entity.HasOne(p => p.City).WithMany(p => p.Towns).OnDelete(DeleteBehavior.Cascade);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class City
    {
        internal partial class Town : BaseEntity
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public double ShippingCost { get; set; }
            public Guid CityId { get; set; }

            [ForeignKey(nameof(CityId))]
            public virtual Designer.City City { get; set; }

            public virtual ICollection<Designer.Order> OrderInvoices { get; set; }
            public virtual ICollection<Designer.Order> OrderShippings { get; set; }
        }
    }
}