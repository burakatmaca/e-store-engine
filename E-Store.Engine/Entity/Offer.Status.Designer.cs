using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Offer.Status> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Offer_Status");
                entity.Property(p => p.OfferId).HasField("Offer_Id");


                entity.HasOne(p => p.Offer).WithMany(p => p.Statuses).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Offer
    {
        internal partial class Status : BaseEntity
        {
            public Guid OfferId { get; set; }
            public OfferStatusTypes Type { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }

            [ForeignKey(nameof(OfferId))]
            public virtual Designer.Offer Offer { get; set; }
        }
    }

    enum OfferStatusTypes
    {
        [Display(Name = "Oluşturuldu")]
        Created = 0,

        [Display(Name = "Teklif Hazırlandı")]
        Prepared = 1,

        [Display(Name = "Satış Tamamlandı")]
        Completed = 2,

        [Display(Name = "Geçerlilik Süresi Sona Erdi")]
        Expired = 3
    }
}