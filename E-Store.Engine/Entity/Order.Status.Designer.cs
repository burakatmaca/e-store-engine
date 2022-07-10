using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Order.Status> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Order_Status");
                entity.Property(p => p.OrderId).HasField("Order_Id");

                entity.HasOne(p => p.Order).WithMany(p => p.Statuses).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Order
    {
        internal partial class Status : BaseEntity
        {
            public Guid OrderId { get; set; }
            public OrderStatusTypes Type { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }

            [ForeignKey(nameof(OrderId))]
            public virtual Designer.Order Order { get; set; }
        }
    }

    enum OrderStatusTypes
    {
        [Display(Name = "Oluşturuldu")]
        Created = 0,

        [Display(Name = "Onaylandı")]
        Approved = 1,

        [Display(Name = "Hazırlanıyor")]
        Preparing = 2,

        [Display(Name = "Kargoya Teslim Edildi")]
        Shipped = 3,

        [Display(Name = "Tamamlandı")]
        Completed = 4,

        [Display(Name = "İptal Edildi")]
        Canceled = 5
    }
}