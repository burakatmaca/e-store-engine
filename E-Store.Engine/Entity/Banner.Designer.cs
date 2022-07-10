using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Banner> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Banner");
                entity.Property(p => p.OwnerId).HasField("Owner_Id");
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Banner : BaseEntity
    {
        public BannerTypes Type { get; set; }
        public Guid? OwnerId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Sort { get; set; }
        public bool IsActive { get; set; }
    }

    public enum BannerTypes
    {
        [Display(Name = "Sayfa Üst Bölüm")]
        Header = 0,

        [Display(Name = "Sayfa Alt Bölüm")]
        Footer = 1,

        [Display(Name = "Anasayfa Orta Bölüm")]
        HomeMiddle = 2,

        [Display(Name = "Anasayfa Alt Bölüm")]
        HomeFooter = 3,

        [Display(Name = "Kategori Orta Bölüm")]
        CategoryMiddle = 4,

        [Display(Name = "Kategori Alt Bölüm")]
        CategoryFooter = 5,

        [Display(Name = "Sepet Yan Bölüm")]
        CartSidebar = 6,

        [Display(Name = "Teslimat ve Ödeme Yan Bölüm")]
        OrderSidebar = 7
    }
}