using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Offer> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Offer");
                entity.Property(p => p.Code).HasMaxLength(25);
                entity.Property(p => p.Title).HasMaxLength(150);
                entity.Property(p => p.Email).HasMaxLength(100);
                entity.Property(p => p.ProductId).HasField("Product_Id");
                entity.Property(p => p.CurrentStatusId).HasField("Current_Status_Id");


                entity.HasIndex(p => p.Code).IsUnique();
                entity.HasIndex(p => p.CurrentStatusId);

                entity.HasOne(p => p.Product).WithMany(p => p.Offers).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Offer : BaseEntity
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Guid ProductId { get; set; }
        public Guid? CurrentStatusId { get; set; }

        [ForeignKey(nameof(CurrentStatusId))]
        public virtual Designer.Offer.Status CurrentStatus { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Designer.Product Product { get; set; }

        public virtual ICollection<Designer.Offer.Status> Statuses { get; set; }

        public Offer()
        {
            this.Statuses = new HashSet<Designer.Offer.Status>();
        }
    }
}