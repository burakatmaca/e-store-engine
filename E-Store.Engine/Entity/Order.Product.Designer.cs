using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Store.Engine.Entity
{
    static partial class DataModelBuilderExtensions
    {
        internal static void EntityConfiguration(this EntityTypeBuilder<Entity.Designer.Order.Product> entityBuilder)
            => entityBuilder.BaseEntityConfiguration(entity =>
            {
                entity.HasBaseType("Order_Product");
                entity.Property(p => p.OrderId).HasField("Order_Id");
                entity.Property(p => p.ProductId).HasField("Product_Id");
                entity.Property(p => p.CurrencyRateId).HasField("Currency_Rate_Id");

                entity.HasOne(p => p.CurrencyRate).WithMany(p => p.Orders).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
                entity.HasOne(p => p.Order).WithMany(p => p.Products).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
                entity.HasOne(p => p.Product_).WithMany(p => p.Orders).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            });
    }
}

namespace E_Store.Engine.Entity.Designer
{
    partial class Order
    {
        internal partial class Product : BaseEntity
        {
            public Guid OrderId { get; set; }
            public Guid ProductId { get; set; }
            public string FeatureInformation { get; set; }
            public int Quantity { get; set; }
            public double Amount { get; set; }
            public double? DiscountRate { get; set; }
            public double TaxRate { get; set; }
            public double TaxAmount { get; set; }
            public Guid CurrencyRateId { get; set; }

            [ForeignKey(nameof(CurrencyRateId))]
            public virtual Designer.Currency.Rate CurrencyRate { get; set; }

            [ForeignKey(nameof(ProductId))]
            public virtual Designer.Product Product_ { get; set; }

            [ForeignKey(nameof(OrderId))]
            public virtual Designer.Order Order { get; set; }
        }
    }
}