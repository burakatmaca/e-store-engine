using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Product> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Product");
                entity.Property(p => p.Code).HasMaxLength(10);
                entity.Property(p => p.Name).HasMaxLength(150);
                entity.Property(p => p.Url).HasMaxLength(250);
                entity.Property(p => p.MetaTitle).HasMaxLength(150);
                entity.Property(p => p.CurrencyId).HasField("Currency_Id");

                entity.HasIndex(p => p.Code).IsUnique();
                entity.HasIndex(p => new { p.Url, p.Code }).IsUnique();
                entity.HasOne(p => p.Currency).WithMany(p => p.Products).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Product : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double? DiscountRate { get; set; }
        public double Tax { get; set; }
        public bool TaxInclude { get; set; }
        public Guid CurrencyId { get; set; }
        public ProductTypes Type { get; set; }
        public StockTypes StockType { get; set; }
        public bool ShownOnHomePage { get; set; }
        public bool IsDomesticProduction { get; set; }
        public WarrantyTypes WarrantyType { get; set; }
        public string Url { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        public virtual Designer.Currency Currency { get; set; }

        public virtual ICollection<Designer.Product.Category> Categories { get; set; }
        public virtual ICollection<Designer.Product.Feature> Features { get; set; }
        public virtual ICollection<Designer.Order.Product> Orders { get; set; }
        public virtual ICollection<Designer.Offer> Offers { get; set; }

        public Product()
        {
            this.Categories = new HashSet<Designer.Product.Category>();
            this.Features = new HashSet<Designer.Product.Feature>();
        }
    }

    enum ProductTypes
    {
        [Display(Name = "Hemen Teslim")]
        Stock = 0,

        [Display(Name = "Özel İmalat")]
        Custom = 1
    }

    enum StockTypes
    {
        [Display(Name = "Stokta Yok")]
        OutStock = 0,

        [Display(Name = "Stokta Var")]
        InStock = 1
    }

    enum WarrantyTypes
    {
        [Display(Name = "Yok")]
        None = 0,

        [Display(Name = "Üretici Firma Garantisi")]
        Manufacturer = 1,

        [Display(Name = "6 Ay Garantili")]
        SixMonth = 6,

        [Display(Name = "12 Ay Garantili")]
        TwelveMonth = 12,

        [Display(Name = "24 Ay Garantili")]
        TwentyFour = 24
    }
}